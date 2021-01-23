    //Act
    using (var test_Stream = this.GetType().Assembly.GetManifestResourceStream("excelFileResource"))
    {
        var result = imp.Import(test_Stream);
    
        // Assert    
        Assert.IsTrue(result);
    }
