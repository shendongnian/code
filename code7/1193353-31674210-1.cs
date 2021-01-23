    [TestCase(5, 0x05, 0x00, 0x00, 0x00)]
    [TestCase(1500, 0xDC, 0x05, 0x00, 0x00)]
    public void TestConvert(int i, byte b0, byte b1, byte b2, byte b3)
    {
        Binary testBinary = i;
        Assert.AreEqual(b0, testBinary.Value[0]);
        Assert.AreEqual(b1, testBinary.Value[1]);
        Assert.AreEqual(b2, testBinary.Value[2]);
        Assert.AreEqual(b3, testBinary.Value[3]);
        int testInt = new Binary(new[] { b0, b1, b2, b3 });
        Assert.AreEqual(testInt, i);
    }
