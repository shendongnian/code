    [TestFixture]
    internal class LowerTests
    {
        [Test]
        public void Test_asdf_asdf()
        {
            var actual = ToLowerEx.Get("asdf");
            const string expected = "asdf";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_Asdf_asdf()
        {
            var actual = ToLowerEx.Get("Asdf");
            const string expected = "asdf";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_aSdf_asdf()
        {
            var actual = ToLowerEx.Get("aSdf");
            const string expected = "asdf";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_ASDF_ASDF()
        {
            var actual = ToLowerEx.Get("ASDF");
            const string expected = "ASDF";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_asdfAndqwer_asdfAandqwer()
        {
            var actual = ToLowerEx.Get("asdf, qwer");
            const string expected = "asdf, qwer";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_AsdfAndqWer_asdfAandqwer()
        {
            var actual = ToLowerEx.Get("Asdf, qWer");
            const string expected = "asdf, qwer";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_AsdfAndQWER_asdfAandQWER()
        {
            var actual = ToLowerEx.Get("Asdf, QWER");
            const string expected = "asdf, QWER";
            Assert.AreEqual(expected, actual);
        }
    }
