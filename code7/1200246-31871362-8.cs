            using (FileStream fs = File.Open(@"C:\Temp\1.pb", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    // ... read something                       
                    reader.ReadLine();
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        // ... write something
                        writer.WriteLine("hello");
                    }
                }
            }
