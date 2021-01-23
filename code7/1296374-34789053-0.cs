    class Program
    {
        static void Main(string[] args)
        {
            var root = XElement.Load("1.xml");
            var compIDs = root.Elements()
                          .GroupBy(r => r.Element("Name").Value)
                          .Select(group => new 
                                            {
                                                Group = group.Key,
                                                Items = group.First().Elements("IDs").Elements("ID")
                                                        .Select(id => new Regex("<ID>(.*)</ID>").Match(id.ToString()).Groups[1].ToString())
                                                        .OrderBy(value => value)
                                                        .ToArray()
                                            }
                                  )
                          .ToArray();
            using (var sw = new StreamWriter("results.txt"))
            {
                foreach (var group in compIDs)
                {
                    sw.WriteLine("Size: " + group.Group + "\r\nIDs:");
                    foreach (var id in group.Items)
                        sw.WriteLine(id);
                }
            }
        }
    }
