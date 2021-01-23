    public void Deserialize(byte[] arg)
    {
        using (var ms = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            ms.Write(arg, 0, arg.Length);
            ms.Seek(0, SeekOrigin.Begin);
            Frame objArray = (Frame)bf.Deserialize(ms);
            this.Id = objArray.Id;
            this.Timestamp = objArray.Timestamp;
            this.CurrentFramesPerSecond = objArray.CurrentFramesPerSecond;
            this.InteractionBox = objArray.InteractionBox;
            this.Hands = objArray.Hands;
        }
    }
