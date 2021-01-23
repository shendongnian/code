        [TestClass]
        public class PersonUnitTests
        {
            [TestMethod]
            public void TestPersonRelativeAge()
            {
                var p = new Person("Jane", 1986, "F");
                Assert.AreEqual(p.RelativeAge, 30);
            }
            [TestMethod]
            public void TestAgeStatement()
            {
                var p = new Person("Jane", 1986, "F");
                Assert.AreEqual(p.AgeStatement(), "Jane is 30 years old.");
            }
        }
