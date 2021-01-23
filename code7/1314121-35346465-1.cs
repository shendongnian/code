            using (StreamWriter sw = new StreamWriter(File.Create(pathString)))
            {
                richTextBox1.Clear();
                string[] lines = { "First line", "Second line", "Third line" };
                richTextBox1.AppendText("Prašome atsidaryti failą ir jį pakeisti. Failas yra : " + pathString + Environment.NewLine);
                foreach (var line in lines)
                {
                    sw.WriteLine(line);
                }
            }
