    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        string path = @"F:\DXHyperlink\Book.txt";
        const int chunkSize = 1024;
        using (var file = File.OpenRead(path))
        {
            var buffer = new byte[chunkSize];
            while ((file.Read(buffer, 0, buffer.Length)) > 0)
            {
                string stringData = System.Text.Encoding.UTF8.GetString(buffer);
                AppendText(string.Join(Environment.NewLine, stringData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)));
            }
        }
    }
 
