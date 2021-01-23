    using System.IO;
    using System.Threading.Tasks;
    using System.Xml;
    using Windows.Storage;
    using Windows.ApplicationModel;
    async public Task ReadXmlFile()
    {
        // Use ONE of the following lines to get the file:
        var sf = await Package.Current.InstalledLocation.TryGetItemAsync("projectdates.xml") as StorageFile;
        var sf = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///projectdates.xml"));
        var stream = await sf.OpenStreamForReadAsync();
        XmlReader xml = XmlReader.Create(stream);
        ...
    }
