    class Example
        {
            public void GetFile()
            {
                var fileMapper = new Dictionary<string, string>
                {
                    ["obj"] = "sfsfs",
                    ["obj.attribute"] = "sfsfs"
                };
    
                var fileLines = new List<string>();
    
                using (var sr = new StreamReader("FileName"))
                {
                    var line = string.Empty;
    
                    while ((line = sr.ReadLine()) != null)
                    {
                        List<string> listOfPlaceHolders = this.GetPlaceHolders(line);
    
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
            }
    
            public List<string> GetPlaceHolders(string line)
            {
                var result = new List<string>();
    
                var placeHoldersIndex = new List<int>();
    
                var open = false;
    
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == '{' && !open)
                    {
                        open = true;
                        placeHoldersIndex.Add(i);
                    }
    
                    if (line[i] == '}' && open)
                    {
                        placeHoldersIndex.Add(i);
                        open = false;
                    }
                }
    
                for (var j = 0; j < placeHoldersIndex.Count(); j += 2)
                {
                    result.Add(line.Substring(j, j + 1));
                };
    
                return result;
            }
    
        }
