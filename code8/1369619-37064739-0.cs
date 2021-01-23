    List<string> list = new List<string>();
                var textfile = File.ReadAllLines(@"D:\test.txt");
                foreach (var line in textfile)
                {
                string result = Regex.Match(line, @"\d+").Value;
                    list.Add(result);
                }
                string numbers = string.Join(",",list.ToArray());
