    [TestMethod]
    public void ExtractXmlFromZip_Test()
    {
        var myThing = new MyObj();
        var fileName = "my.zip";
        ZipArchive myZipArchive = CreateTestZipFile(); // Set up your return
        
        var mockWrapper = new Mock<IZipFileWrapper>();    
        mockWrapper.Setup(m => m.OpenRead(fileName)).Returns(myZipArchive);
    
            var configs = myThing.ExtractXmlFromZip(fileName);
            // Assert
        }
    }
