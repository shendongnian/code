     static void Main()
            {
                int counter = 0; string line;
               
                List<string> ss = new List<string>();
                using (System.IO.StreamReader file = new System.IO.StreamReader(@"E:\file\log.txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        
                        if (line.Contains(DateTime.Now.Date.ToShortDateString()))
                        {
                            ss.Add(line);                     
                            line = file.ReadLine();
                            if (line != null)
                          
                                ss.Add(line);
                            line = file.ReadLine();
                            if (line != null)                           
                                ss.Add(line);
                        
                        }
                    }
                }
    
                var item = ss.LastOrDefault();            
                string number = item.Substring(0, 24).Replace("NUMBER:", "").Trim();
                Console.WriteLine(number);
                Console.ReadKey();
    }
