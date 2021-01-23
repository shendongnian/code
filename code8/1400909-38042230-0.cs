                var request = System.Net.WebRequest.Create("http://make-sense.co.il/kb/avcp-script-installation.pdf");
                request.Method = "GET";
                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var fileStream = System.IO.File.Create(@"path/to/file"))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
