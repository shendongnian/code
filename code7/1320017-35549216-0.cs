        private void btnStart_Click(object sender, EventArgs e)
        {
            int count, size;
            count = Int32.Parse(tbCount.Text);
            size = Int32.Parse(tbSize.Text);
            string path = tbPath.Text;
            string stringToWrite = new string('A', size);
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for(int i=0;i<count;i++)
            {
                string fileName = System.IO.Path.Combine(path, i.ToString() + ".tst");
                System.IO.File.AppendAllText(fileName, stringToWrite);
            }
            sw.Stop();
            tbLog.Text += String.Format("{0} files with length {1} saved to {2} in {3}ms"+Environment.NewLine, count, size, path, sw.ElapsedMilliseconds);
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            int count;
            count = Int32.Parse(tbCount.Text);
            string path = tbPath.Text;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                string fileName = System.IO.Path.Combine(path, i.ToString() + ".tst");
                string temp = System.IO.File.ReadAllText(fileName);
            }
            sw.Stop();
            tbLog.Text += String.Format("{0} files loaded from {1} in {2}ms" + Environment.NewLine, count, path, sw.ElapsedMilliseconds);
        }
