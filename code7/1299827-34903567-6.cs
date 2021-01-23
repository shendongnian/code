    var fileMapper = new Dictionary<string, string>
                        {
                            ["obj"] = "sfsfs",
                            ["obj.attribute"] = "sfsfs"
                        };
    
    
                        var fileLines = new List<string>();
    
                        using (var sr = new StreamReader(fileName))
                        {
                            var line = string.Empty;
    
                            while ((line = sr.ReadLine()) != null)
                            {
                                List<string> listOfPlaceHolders = line.GetPlaceHolders();
    
                                for (var i = 0; i < listOfPlaceHolders.Count; i++)
                                {
                                    line = line.Replace(listOfPlaceHolders[i], fileMapper[listOfPlaceHolders[i]]);
                                }
    
                                fileLines.Add(line);
                            }
                        }
    
    
                        foreach (var line in fileLines)
                        {
                            Console.WriteLine(line);
                        }
