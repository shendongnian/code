    private void Enable(TextBox Temp, string system)
    {
        // check that the property even exists
        bool propertyExists = Properties.Settings.Default.Properties.Cast<SettingsProperty>().Any(p => p.Name == system);
        if (propertyExists)
        {
            Properties.Settings.Default[system] = Temp.Text;
        }
        else
        {
            // create a new property
            var p = new SettingsProperty(system);
            p.PropertyType = typeof(string);
            p.DefaultValue = Temp.Text;
            Properties.Settings.Default.Properties.Add(p);
        }
    
        Properties.Settings.Default.Save();
    }
