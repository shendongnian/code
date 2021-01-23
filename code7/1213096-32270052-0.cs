    private void CreateSettingsFile(string path)
        {
            XDocument document = new XDocument();
            XElement rootElement = new XElement("settings");
            document.Add(rootElement);
            document.Save(path);
            var accessControl = File.GetAccessControl(path);
            var everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            accessControl.AddAccessRule(new FileSystemAccessRule(everyone,
                                                                FileSystemRights.FullControl |
                                                                FileSystemRights.Synchronize,
                                                                AccessControlType.Allow));
            manager = new XmlSettingsManager(document, () => XDocument.Load("file://" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.settingsPath)),
                x => x.Save(this.settingsPath));
            File.SetAccessControl(path, accessControl);
        }
 
