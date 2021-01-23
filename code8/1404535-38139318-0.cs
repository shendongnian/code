    public void Save(string filename)
    {
        var bin_formater = new BinaryFormatter();
        using (var stream = File.Create(filename))
        {
            bin_formater.Serialize(stream, images); //images is your dictionary
        }
    }
