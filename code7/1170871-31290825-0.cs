    class SampleDataSource : DataSource {
         Assembly InterfaceAssembly;
         string[] names;
         public SampleDataSource() {
            InterfaceAssembly = typeof(Interface.HTMLInterface).Assembly;
            // Get the names of all the resources in the assembly
            names = InterfaceAssembly.GetManifestResourceNames();
            Array.Sort(names, CaseInsensitiveComparer.Default);
         }
         protected override void OnRequest(DataSourceRequest request) {
            var response = new DataSourceResponse();
            string[] parts = request.Path.Replace("\\", "/").Split('/');
            for (int i = 0; i < parts.Length - 1; i++) {
               parts[i] = parts[i].Replace(".", "_").Replace("-", "_");
            }
            string resourcePath = "Interface.html." + request.Path
               //.Replace(".", "_")
               .Replace("/", ".")
               .Replace("\\", ".");
            resourcePath = "Interface.html." + String.Join(".", parts);
            // Find the image in the names array
            int pos = Array.BinarySearch(names, resourcePath, CaseInsensitiveComparer.Default);
            if (pos > -1) {
               resourcePath = names[pos];
            }
            byte[] data = null;
            using (Stream stream = InterfaceAssembly.GetManifestResourceStream(resourcePath)) {
               data = new byte[stream.Length];
               stream.Read(data, 0, data.Length);
            }
            IntPtr unmanagedPointer = IntPtr.Zero;
            try {
               unmanagedPointer = Marshal.AllocHGlobal(data.Length);
               Marshal.Copy(data, 0, unmanagedPointer, data.Length);
               response.Buffer = unmanagedPointer;
               switch (System.IO.Path.GetExtension(request.Path).ToLower()) {
                  case ".html":
                  case ".htm":
                     response.MimeType = "text/html";
                     break;
                  case ".js":
                     response.MimeType = "application/javascript";
                     break;
                  case ".css":
                     response.MimeType = "text/css";
                     break;
                  case ".png":
                     response.MimeType = "image/png";
                     break;
                  case ".jpeg":
                  case ".jpg":
                     response.MimeType = "image/jpeg";
                     break;
                  default:
                     response.MimeType = "text/html";
                     break;
               }
               response.Size = (uint)data.Length;
               SendResponse(request, response);
            }
            catch (Exception e) {
               throw e;
            }
            finally {
               Marshal.FreeHGlobal(unmanagedPointer);
            }
         }
      }
