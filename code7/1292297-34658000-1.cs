            string treated = Process();
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"c:\foo\stestTreated.txt", false, Encoding.Unicode))
            {
                writer.Write(treated);
                writer.Close();
            }
