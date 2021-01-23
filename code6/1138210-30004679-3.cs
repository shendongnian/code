    private object getPropertyValue(string settingValue, Type settingType, SettingsSerializeAs serializeAs)
    {
        switch (serializeAs)
        {
            case SettingsSerializeAs.String:
                return Convert.ChangeType(settingValue, settingType);
            case SettingsSerializeAs.Xml:
                //for demo purposes, assumes this is your int array--otherwise do further checking to get the correct type
                XmlSerializer serializer = new XmlSerializer(typeof(int[]));
                return serializer.Deserialize(new StringReader(settingValue));
            //implement further types as required
            default:
                throw new NotImplementedException(string.Format("Settings deserialization as {0} is not implemented", serializeAs));
        }
    }
    
