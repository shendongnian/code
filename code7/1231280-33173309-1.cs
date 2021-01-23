        private void buttonOther_Click(object sender, EventArgs e)
        {
            PrintDocument(filename);
        }
        private void PrintDocument(string filename)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = filename;
            Process p = new Process();
            p.StartInfo = info;
            p.Start();
        }
