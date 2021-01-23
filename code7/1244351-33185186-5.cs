    private string SettingToString(PrinterSettings settings)
    {
        if (settings == null)
            return null;
            
        var bf = new BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            bf.Serialize(ms, settings);
            return Convert.ToBase64String(ms.ToArray());
        }
    }
    private PrinterSettings SettingFromString(string base64)
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream(Convert.FromBase64String(base64)))
            {
                return (PrinterSettings)bf.Deserialize(ms);
            }
        }
        catch (Exception)
        {
            return new PrinterSettings();
        }
    }
