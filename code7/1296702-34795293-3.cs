    [TestMethod]
    public void TestMethod1()
    {
        using (ShimsContext.Create())
        {
            System.Fakes.ShimEnvironment.OSVersionGet = () => new OperatingSystem(PlatformID.Win32Windows, new Version("99.99"));
            Assert.AreEqual(Environment.OSVersion.Version.Major, 99);
        }
    }
