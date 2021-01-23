    public static string[] SplitWithDelimeter(this string line, char separator, char checkSeparator, bool eraseCheckSeparator)
            {
                var separatorsIndexes = new List<int>();
                
                var open = false;
    
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == checkSeparator)
                    {
                        open = !open;
                    }
    
                    if (!open && line[i] == separator )
                    {
                        separatorsIndexes.Add(i);
                    }
                }
    
                separatorsIndexes.Add(line.Length);
    
                var result = new string[separatorsIndexes.Count];
                
                var first = 0;
    
                for (var j = 0; j < separatorsIndexes.Count; j++)
                {
                    var tempLine = line.Substring(first, separatorsIndexes[j] - first);
    
                    result[j] = eraseCheckSeparator ? tempLine.Replace(checkSeparator, ' ').Trim() : tempLine;
    
                    first = separatorsIndexes[j] + 1;
                }
                
                return result;
            }
