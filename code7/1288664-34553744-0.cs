    public struct TestShimOfStruct
    {
        public int Year { get; set; }
    }
    public class TestShimOfClass
    {
        public int Year { get; set; }
    }
    ...
    [TestMethod]
    public void TestStructAndClass()
    {
        using (ShimsContext.Create())
        {
            PartialTest.Fakes.ShimTestShimOfClass.AllInstances.YearGet = shimClass => 2015;
            PartialTest.Fakes.ShimTestShimOfStruct.AllInstances.YearGet = shimClass => 2015;
        }
    }
