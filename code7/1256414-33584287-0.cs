    foreach (SettingsPropertyValue property in Lab.Properties.Settings.Default.PropertyValues)
    {
        try
        {
            String name = Convert.ToString(property.Name);
            String value = Convert.ToString(property.PropertyValue);
            Console.WriteLine("{0}:{1}", name, value);
            Debug.WriteLine("Loading from settings: {0} - {1}", name, value);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
