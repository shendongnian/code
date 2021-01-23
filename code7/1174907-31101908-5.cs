    [Test]
    public static void TestDirectoryFinderGetDirectoryWithOKExpectThePath()
    {
        const string expectedPath = @"C:\temp";
        var dlg = new FakeFolderBrowserDialogWrapper(expectedPath, DialogResult.OK);
        var df = new DirectoryFinder();
        string result = df.GetDirectory(dlg);
        Assert.That(result, Is.EqualTo(expectedPath));
    }
    [Test]
    public static void TestDirectoryFinderGetDirectoryWithCancelExpectEmptyString()
    {
        const string expectedPath = @"C:\temp";
        var dlg = new FakeFolderBrowserDialogWrapper(expectedPath, DialogResult.Cancel);
        var df = new DirectoryFinder();
        string result = df.GetDirectory(dlg);
        Assert.That(result, Is.EqualTo(string.Empty));
    }
