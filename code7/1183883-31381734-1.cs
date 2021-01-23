                foreach (var fileNameAndSize in FileNameAndSizes)
                {
                    var name = fileNameAndSize.Key;
                    //var size = fileNameAndSize.Value;
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead("http://example.com/" + name);
                    TextReader reader = new StreamReader(stream);
                    String content = reader.ReadToEnd();
                    //Other something ...
                }
