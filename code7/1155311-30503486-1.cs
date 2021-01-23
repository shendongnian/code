        private async Task<Settings> LoadSettings()
        {
            Settings settings = new Settings(); 
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                var file = await folder.GetFileAsync("Settings.XML");
                XmlSerializer SerializerObj = new XmlSerializer(typeof(Settings));
                settings = SerializerObj.Deserialize(await file.OpenStreamForReadAsync()) as Settings;
            }
            catch (Exception ex)
            {
                // handle any kind of exceptions
            }
            return settings;
        }
