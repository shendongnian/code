    private static void removeSetting(string _class,string value)
            {
                try
                {
                    //read all lines from file
                    string[] allSettings = File.ReadAllLines("DATA.properties");
    
                    //divide string on string[] by '='
                    List<List<string>> strings = allSettings.Select(x => x.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
    
                    //find all lines wher first element equals _class
                    List<List<string>> result = strings.Where(x => x.First().Equals(_class)).Select(x=>new List<string>{_class, value}).ToList();
    
                    // convert string[] => string
                    string[] secondResult = result.Select(x => String.Join("=",x.ToArray())).ToArray();
    
                    List<List<string>> otherResult = strings.Where(x => !x.First().Equals(_class)).Select(x => x).ToList();
    
                    string[] firstResult = otherResult.Select(x => String.Join("=", x.ToArray())).ToArray();
    
                    //wrtie all lines in file
                    File.WriteAllLines("DATA.properties",firstResult);
    
                    File.AppendAllLines("DATA.properties", secondResult);
                }
                catch (Exception ex)
                {
    
                }
            }
