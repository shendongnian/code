            string testString = "A String with a newline here\r\n and a null here\0 then another newline\r\n then another null\0";
            StreamWriter writer = new StreamWriter(@"c:\temp\testfile123.txt");
            writer.Write(testString);
            writer.Flush();
            writer.Close();            
            writer.Dispose();
            List<string> strings = new List<string>();
            List<string> strings2 = new List<string>();
            MemoryStream memStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(testString));
            using (CustomStreamReader reader = new CustomStreamReader(memStream))
            {
                bool setPos = true;
                while (reader.EndOfStream == false)
                {
                    if (setPos) 
                    { 
                        memStream.Position = 0;
                        setPos = false;
                    }                    
                    strings.Add(reader.ReadLineOrNullString());
                }
            }
            using (CustomStreamReader reader = new CustomStreamReader(@"c:\temp\testfile123.txt"))
            {
                bool setPos = true;
                while (reader.EndOfStream == false)
                {
                    /*if (setPos)
                    {
                        memStream.Position = 0;
                        setPos = false;
                    }*/
                    strings2.Add(reader.ReadLineOrNullString());
                }
            }
            System.Diagnostics.Debugger.Break();
