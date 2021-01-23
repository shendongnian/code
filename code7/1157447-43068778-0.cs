    public class Tests
    { 
        [Theory]
        [MemberData("TestCases", MemberType = typeof(TestDataProvider))]
        public void IsLargerTest(string testName, int a, int b)
        {
            Assert.True(b>a);
        }
    }
    public class TestDataProvider
    {
        public static IEnumerable<object[]> TestCases()
        {
            yield return new object[] {"case1", 1, 2};
            yield return new object[] {"case2", 2, 3};
            yield return new object[] {"case3", 3, 4};
        }
    }
