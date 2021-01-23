        using System;
        using System.Threading.Tasks;
        using Windows.Storage;
        using Windows.Storage.Streams;
        using Windows.Web.Http;
        // ...
        public static bool UploadImageToServer(StorageFile imageFile)
        {
            bool saveRes = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    if (client != null) // if no Network Connection
                    {
                        HttpResponseMessage response = new HttpResponseMessage();
                        Task task = Task.Run(async () =>
                        {
                            using (HttpMultipartFormDataContent formData = new HttpMultipartFormDataContent())
                            {
                                IBuffer buffer = await FileIO.ReadBufferAsync(imageFile);
                                HttpBufferContent WebHTTPContent = new HttpBufferContent(buffer);
                                formData.Add(WebHTTPContent, "UploadedImage", imageFile.Name);
                                response = await client.PostAsync(App.VehicleImageUri, formData);
                                if (response.IsSuccessStatusCode) saveRes = true;
                            }
                        });
                        task.Wait();
                    }
                }
            }
            catch (Exception em)
            {
               // Handle exception here ... 
            }
            return saveRes;
        }
