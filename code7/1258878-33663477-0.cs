    string file = this.cnicloc_txt.Text.Trim();
    if (!string.IsNullOrEmpty(file))
    {
        byte[] imageBt = null;
        FileStream fstream = new FileStream(file, FileMode.Open,
        FileAccess.Read);
        BinaryReader br = new BinaryReader(fstream);
        imageBt = br.ReadBytes((int)fstream.Length);
    }
