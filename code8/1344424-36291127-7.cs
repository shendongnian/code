    [TestCaseSource(nameof(Conversions))]
    public void TestMethodIntToBin(int intToConvert, string result)
    {
        // Asserts
    }
    static object[] Conversions = {
        new object[] { 12, "00110110" },
        new object[] { 13, "00110110" }
    }
