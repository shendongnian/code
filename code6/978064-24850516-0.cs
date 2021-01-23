            var fileResponse = (HttpWebResponse)fileRequest.GetResponse();
            if (fileResponse.StatusCode == HttpStatusCode.OK)
            {
                var responseStream = fileResponse.GetResponseStream();
                if (responseStream != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        responseStream.CopyTo(ms);
                        ms.Position = 0;
                        using (var fs = System.IO.File.Create(@"C:\Temp\Bytes\helloworldbytes.bmp"))
                        {
                            ms.CopyTo(fs);
                        }
                    }
                }
            }
