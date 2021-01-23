           var webClient = new WebClient();
           const string baseUrl = @"http://automet.fugrogeos.com:9090/pub/singapore";
           const string diskPath = @"c:\MyFiles\";
           string content = webClient.DownloadString(baseUrl);
           var htmlLinks = content.Split(new[] {"</A>"}, StringSplitOptions.RemoveEmptyEntries);
           var paths = new List<string>();
           foreach (var htmlLink in htmlLinks)
           {
               var linkHrefs = htmlLink.Split(new[] { @"<A HREF=" }, StringSplitOptions.RemoveEmptyEntries);
               foreach (var linkHref in linkHrefs.Where(h => h.ToLower().Contains(".bz2"))) 
               {
                   var fileRefs = linkHref.Split(new[] {">"}, StringSplitOptions.RemoveEmptyEntries);
                   paths.Add(fileRefs[fileRefs.Length - 1]);
               }
           }
           foreach (var path in paths)
           {
              var bytes =  webClient.DownloadData(new Uri(baseUrl + path));
              File.WriteAllBytes(diskPath+ path, bytes);
           }
