        var configXml = GetAppConfigXml(); // Returns the XML shown in your question.
        var config = (SystemConfigurationSection)Activator.CreateInstance(typeof(SystemConfigurationSection), true);
        using (var sr = new StringReader(configXml))
        using (var xmlReader = XmlReader.Create(sr))
        {
            if (xmlReader.ReadToDescendant("SystemConfiguration"))
                using (var subReader = xmlReader.ReadSubtree())
                {
                    var dynMethod = config.GetType().GetMethod("DeserializeSection", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(XmlReader) }, null);
                    dynMethod.Invoke(config, new object[] { subReader });
                }
        }
        Debug.Assert(config.Equipments.Count == 2); // No assert
