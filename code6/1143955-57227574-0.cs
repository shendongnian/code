        using (var zip = new Ionic.Zip.ZipFile())
                    {
                        zip.AddEntry($"file1.json", new MemoryStream(Encoding.UTF8.GetBytes(someJsonContent)));
    
                            for (int i = 0; i < 4; i++)
                            {
                                zip.AddEntry($"{myDir}/{i}.json", new MemoryStream(Encoding.UTF8.GetBytes(anotherJsonContent)));
                            }
                    }
