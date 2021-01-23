    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace BasicDataStorageApp
    {
        public static class FileHelper
        {
            public static bool WriteLines(IEnumerable<string> lines, string filename, bool append)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(filename, append))
                    {
                        foreach (var line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
    
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            public static bool WriteLine(string line, string filename, bool append)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(filename, append))
                    {
                        writer.WriteLine(line);
                    }
    
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            public static IEnumerable<string> ReadLines(string filename)
            {
                try
                {
                    var lines = new List<string>();
    
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        string line = null;
                        while ((line = reader.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }
    
                    return lines;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
