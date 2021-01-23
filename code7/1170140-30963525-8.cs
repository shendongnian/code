    public void LoadFromFile(ContentManager content, string name)
    {
        string path = content.RootDirectory + @"\Objects\Planets\" + name + @".planet";
        using (BinaryReader br = new BinaryReader(File.OpenRead(path)))
        {
            this.name = br.ReadString();
            this.planet = new Animation(Cont.Texture2D(this.name), br.ReadInt32(), br.ReadInt32(), br.ReadDouble(), true);
            this.asteroid1 = Cont.Texture2D(br.ReadString());
            this.asteroid2 = Cont.Texture2D(br.ReadString());
  
  
