        [TestMethod]
        public void TestFloatConst()
        {
            Assert.AreNotEqual(0f, 0.1f + 0.2f - 0.3f);//Broken in VS 2015 Update 2
        }
        [TestMethod]
        public void TestFloatConstComparison()
        {
            Assert.AreNotEqual(0.3f, 0.1f + 0.2f);//Broken in VS 2015 Update 2
        }
        [TestMethod]
        public void TestDoubleConst()
        {
            Assert.AreNotEqual(0d, 0.1d + 0.2d - 0.3d);
        }
        [TestMethod]
        public void TestDoubleConstComparison()
        {
            Assert.AreNotEqual(0.3d, 0.1d + 0.2d);
        }
        [TestMethod]
        public void TestDecimalConst()
        {
            Assert.AreEqual(0m, 0.1m + 0.2m - 0.3m);
        }
        [TestMethod]
        public void TestFloatVariable()
        {
            var a = 0.1f;
            var b = 0.2f;
            var c = 0.3f;
            Assert.AreNotEqual(0f, a+b-c);//OK in both debug and release builds
        }
