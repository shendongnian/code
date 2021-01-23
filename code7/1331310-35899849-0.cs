            private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = @"";
            using (var sr = new StreamReader(filePath))
            {
                string line;
                     
                while ((line = sr.ReadLine()) != null)
                {
                    label1.Text += "\n" + line;
                }
            }
        }
