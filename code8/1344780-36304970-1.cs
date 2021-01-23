    public double GetVolume(string volumeString)
    {
  
        var num = $"{volumeString.Substring(0,2)}.{volumeString.Substring(2)}";
        var vol = double.Parse(num);
        return vol;
    }
