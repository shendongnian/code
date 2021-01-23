    var newString = "";
            var lines = File.ReadAllLines("").ToList();
            foreach (var line in lines)
            {
                if (line.Contains("//") && line.EndsWith("\n"))
                {
                    var startIndex = line.IndexOf("//", StringComparison.Ordinal);
                    var endIndex = line.LastIndexOf("\n", StringComparison.Ordinal);
                    var length = (endIndex + 1) - startIndex;
                    var subString = line.Substring(startIndex, length);
                    var temp = line.Replace(subString, "");
                    newString += temp;
                    //Console.WriteLine(line);
                    continue;
                }
                newString += line;
            }
            //Console.WriteLine(newString);
