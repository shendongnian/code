    public abstract class ParellelTheoryBase
    {
        public static List<int> testValues = new List<int> {1, 2, 3, 4, 5, 6};
    }
    public class ParallelTheory_1of2 : ParellelTheoryBase
    {
        public static List<object[]> theoryData = testValues.Where((data, index) => index % 2 == 0).Select(data => new object[] { data }).ToList();
        [Theory]
        [MemberData(nameof(theoryData))]
        public void DoSomeLongRunningAddition(int data)
        {
            Assert.True(data < 7);
            Thread.Sleep(5000);
        }
    }
    public class ParallelTheory_2of2 : ParellelTheoryBase
    {
        public static List<object[]> theoryData = testValues.Where((data, index) => index % 2 == 1).Select(data => new object[] { data }).ToList();
        [Theory]
        [MemberData(nameof(theoryData))]
        public void DoSomeLongRunningAddition(int data)
        {
            Assert.True(data < 7);
            Thread.Sleep(5000);
        }
    }
