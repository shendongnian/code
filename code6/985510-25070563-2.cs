    if (File.Exists(this.location))
    {
        using (var fileInfo = new FileInfo(this.location)
        {
            using(var writer = fileInfo.CreateText())
            {
                writer.WriteLine("Count=" + Items.Count);
                foreach(var item in Items)
                    writer.WriteLine(item);
            }
        }
    }
