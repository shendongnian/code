    OpenFileDialog fd = new OpenFileDialog();
    if (fd.ShowDialog() == DialogResult.OK)
    {
        StreamReader reader = new StreamReader(fd.OpenFile());
        var list = new List<int>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            int value = 0;
            if (!string.IsNullOrWhiteSpace(line) && int.TryParse(line, out value))
                list.Add(value);
        }
        MessageBox.Show(list.Aggregate("", (x, y) => (string.IsNullOrWhiteSpace(x) ? "" : x + ", ") + y.ToString()));
    }
