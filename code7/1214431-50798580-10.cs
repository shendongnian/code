    public async static Task<StorageFile> GetWindowsStoreProxyXmlAsync(string productKey, bool isActive = false, bool isTrial = false)
        {
            StorageFile xmlFile = null;
            var currentApp = LoadCurrentApp(productKey, isActive, isTrial);
            var xml = StorageHelper.SerializeToXML<CurrentApp>(currentApp);
            if (!string.IsNullOrEmpty(xml))
            {
                xmlFile = await StorageHelper.LocalFolder.CreateFileAsync("MarketData.xml", CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(xmlFile, xml);
            }
            return xmlFile;
        }
