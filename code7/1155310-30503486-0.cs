        private async Task SaveSettings(Settings settings)
        {
            var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var options = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var file = await folder.CreateFileAsync("Settings.XML", options);
            try
            {
                XmlSerializer SerializerObj = new XmlSerializer(typeof(Settings));
                SerializerObj.Serialize(await file.OpenStreamForWriteAsync(), settings);
            }
            catch
            {
                // handle any kind of exceptions
            }
        }
