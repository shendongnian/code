    using(var br = new BinaryReader(
        File.Open(@"c:\tmp\plane.dat", FileMode.Open),
        Encoding.ASCII))
    {
        while(br.BaseStream.Position < br.BaseStream.Length)
        {
            var name = br.ReadString();
            var country = br.ReadString();
            var turnmode = br.ReadChar();
            var attackmode = br.ReadChar();
            var cost = br.ReadDouble();
            var maxdamage = br.ReadInt32();
    
            // you can use above vars what ever you need to do 
            // with them, writing to the console or adding to 
            // a list for example
            // Planes.Add(new Plane {Name = name});
        }
    }
