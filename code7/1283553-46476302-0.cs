                if (File.Exists(charCountFileName)) File.Delete(charCountFileName);
    
                SortedDictionary<ushort, int> charsDict = new SortedDictionary<ushort, int>();
    
                using (StreamReader r = new StreamReader(defs))
                {
                    char[] buffer = new char[1024];
                    int read;
                    while ((read = r.ReadBlock(buffer, 0, buffer.Length)) > 0)
                    {
                        for (int i = 0; i < read; i++)
                        {
                            if (!charsDict.ContainsKey((ushort)buffer[i]))
                            {
                                charsDict.Add((ushort)buffer[i], 1);
                            }
                            else
                                charsDict[(ushort)buffer[i]]++;
                        }
                           
                    }
                }           
    
                using (StreamWriter file = new StreamWriter(new FileStream(charCountFileName, FileMode.Create), Encoding.UTF8))
                    foreach (var entry in charsDict)
                        file.WriteLine("{0}\t{1}\t{2}", entry.Key, Convert.ToChar(entry.Key), entry.Value);
