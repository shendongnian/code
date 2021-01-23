    private DateTime GetDateTakenFromImage(string path)
    {
        using (Image myImage = Image.FromFile(path))
        {
            PropertyItem propItem = myImage.GetPropertyItem(36867);
            string dateTaken = new Regex(":").Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
            return DateTime.Parse(dateTaken);
        }
    }
