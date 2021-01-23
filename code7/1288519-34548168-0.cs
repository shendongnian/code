    bool addNewLine = false;
    using (FileStream fs = new FileStream(@"location", FileMode.Open))
    using (BinaryReader rd = new BinaryReader(fs))
    {
        fs.Position = fs.Length - 1;
        int last = rd.Read();
        if (last == 10)
            addNewLine = true;
    }
    string allLines = (addNewLine ? Environment.NewLine + tb.Text : tb.Text);
    File.AppendAllLines(@"Location", new[]{allLines});
