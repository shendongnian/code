    [TestMethod]
    public void ExtractXmlFromZip_Test()
    {
        var myThing = new MyObj();
        var fileName = "my.zip";
        ZipArchive myZipArchive = CreateTestZipFile(); // Set up your return
        using (ShimsContext.Create())
        {
            System.IO.Compression.Fakes.ShimZipFile.OpenReadString = (filename) => myZipArchive;
            var configs = myThing.ExtractXmlFromZip(fileName);
            // Assert
        }
    }
