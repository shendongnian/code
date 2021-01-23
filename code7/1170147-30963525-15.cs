    public void SaveToFile(ContentManager content)
    {
        string path = content.RootDirectory + @"\Objects\Planets\" + this.name +@".planet"; 
        using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            bw.Write(name);
            //sprite names
            //bw.Write(planet.Sprite.Name); //"planet" is an animation.
            bw.Write(planet.HorFrames);   //and thats why it has a sprite
            bw.Write(planet.VerFrames);   //that has a name
            bw.Write((double)planet.FPS);
    ...
  
  
