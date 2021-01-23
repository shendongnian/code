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
