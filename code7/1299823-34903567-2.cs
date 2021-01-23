    var fileMapper = new Dictionary<string, string>
                        {
                            ["obj"] = "sfsfs",
                            ["obj.attribute"] = "sfsfs"
                        };
    
                        var fileResult = new StringBuilder();
    
    
                        using (var sr = new StreamReader(fileName))
                        {
                            string line;
    
                            while ((line = sr.ReadLine()) != null; )
                            {
                                var listOfplaceholders = line.GetPlaceHolders();
    
                                var newLine = string.Empty;
    
                                for (var i = 0; i < listOfplaceholders.Count; i++)
                                {
                                    fileResult.Append(line.Replace(listOfplaceholders[i], fileMapper[listOfplaceHolders[i]]));
                                }
                            }
                        }
