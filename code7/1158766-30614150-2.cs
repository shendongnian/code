    foreach (var row in rows)
    {
        using (var sw = new StreamWriter(txtreceive.Text + "\\" + "Some variable to identify different patients" + filename))
        {
            sw.WriteLine(header);
            sw.WriteLine(row);
        }
    }
