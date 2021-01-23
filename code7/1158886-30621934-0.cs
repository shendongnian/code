     using (var client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["PAM_WebApi"]);
                    var fileContent = new ByteArrayContent(excelBytes);
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = fileName
                    };
                    content.Add(fileContent);
                    var result = client.PostAsync("api/Product", content).Result;
                }
