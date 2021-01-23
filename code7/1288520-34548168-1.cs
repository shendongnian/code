    bool addNewLine = true;
    using (FileStream fs = new FileStream(@"location", FileMode.Open))
    using (BinaryReader rd = new BinaryReader(fs))
    {
        fs.Position = fs.Length - 1;
        int last = rd.Read();
        // The last byte is 10 if there is a LineFeed 
        if (last == 10)
            addNewLine = false;
    }
    string allLines = (addNewLine ? Environment.NewLine + tb.Text : tb.Text);
    File.AppendAllLines(@"Location", new[]{allLines});
