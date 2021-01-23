            MapiMessage message = MapiMessage.FromFile(msgPath);
            MapiPropertyCollection properties = message.NamedProperties;
    
            foreach (KeyValuePair<long, MapiProperty> prop in properties)
            {
                if (((prop.Value).Descriptor).CanonicalName != null)
                {
                    if (((prop.Value).Descriptor).CanonicalName == "PidLidEmail1DisplayName")
                    {
                        string email1displayName = prop.Value.ToString();                     
                    }
                    if (((prop.Value).Descriptor).CanonicalName == "PidLidEmail1EmailAddress")
                    {
                        string email1Address = prop.Value.ToString();
                    }
                    if (((prop.Value).Descriptor).CanonicalName == "PidLidInstantMessagingAddress")
                    {
                        string ADD = prop.Value.ToString();
                    }
                }
