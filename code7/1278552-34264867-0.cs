    [TestFixture]
    public class TestAddition
    {
        [TestCase(1, 2, 3, Category = "PreCheckin")]
        [TestCase(2, 4, 6)]
        [TestCase(3, 6, 9)]
        public void AdditionPassTest(int first, int second, int expected)
        {
            var adder = new Addition();
            var total = adder.DoAdd(first, second);
            Assert.AreEqual(expected, total);
        }
    }
