    [TestClass]
    public class ColorParserTest
    {
        [TestMethod]
        public void TestParseColorRGB()
        {
            Color c = ColorHelper.ParseColor("rgb(110,120,130)");
            Assert.AreEqual(110, c.R);
            Assert.AreEqual(120, c.G);
            Assert.AreEqual(130, c.B);
            Assert.AreEqual(255, c.A);
        }
        [TestMethod]
        public void TestParseColorRGBA()
        {
            Color c = ColorHelper.ParseColor("rgba(110,120,130,0.5)");
            Assert.AreEqual(110, c.R);
            Assert.AreEqual(120, c.G);
            Assert.AreEqual(130, c.B);
            Assert.AreEqual(127, c.A);
        }
        [TestMethod]
        public void TestParseColorHexa()
        {
            Color c = ColorHelper.ParseColor("#192856");
            Assert.AreEqual(25, c.R);
            Assert.AreEqual(40, c.G);
            Assert.AreEqual(86, c.B);
            Assert.AreEqual(255, c.A);
        }
    }
