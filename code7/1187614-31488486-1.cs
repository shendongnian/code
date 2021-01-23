    using (FileStream fs = File.OpenRead(path)) 
    {
        var br = new BinaryReader(fs);
        br.BaseStream.Seek(BaseStats + (28 * choose), SeekOrigin.Begin);
        HPtb.Text = br.ReadBytes(1)[0].ToString();
        br.Close();
    }
