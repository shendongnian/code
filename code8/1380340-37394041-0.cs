               var path = @"C:\temp\new 1.csv";
                List<String> strcsv = new List<string>();
                using (var rd = new StreamReader(path))
                {
                    while (!rd.EndOfStream)
                    {
                        strcsv.Add(rd.ReadLine());
                    }
                }
    
                //new value
    
                List<String> strcsvNew = new List<string>();
                strcsvNew.Add("new value       ;    new value     ;    new value");
                foreach (var item in strcsv)
                {
                    strcsvNew.Add(item);
                }
    
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
                StreamWriter writer = new StreamWriter(path);
                foreach (var item in strcsvNew)
                {
                    writer.WriteLine(item);
                }
                writer.Dispose();
