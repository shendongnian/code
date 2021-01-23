            using (StreamReader sr = new StreamReader(path)) 
            {
                while (sr.Peek() >= 0) 
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
