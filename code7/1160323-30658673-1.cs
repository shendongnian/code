    var d = File.ReadAllLines(filePath);
                var t = d.Where(g => g.Contains("Message"));
                string[] splited;
                foreach (var item in t)
                {
                    splited = item.Split(new string[] { "Message=" }, StringSplitOptions.None);
                    Console.WriteLine(splited[1]);
                }
