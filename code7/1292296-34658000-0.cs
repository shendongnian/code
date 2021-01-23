        private string Process()
        {
            // You dont need this list
            //List<string> list = new List<string>();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"c:\foo\stest.txt"))
            {
                string line;
                StringBuilder builder = new StringBuilder();
                do
                {
                    line = reader.ReadLine();
                    if (line== null)
                        continue;
                    Console.WriteLine(line); // Write to console.
                     
                    // Process line Here
                     //string[] values = line.Split(',');
                    //list.Add(line); // Add to list.
                    builder.AppendLine(line);
                } while (!reader.EndOfStream);
                return builder.ToString();
            }
        }
