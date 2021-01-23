    [PexClass(typeof(Model))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ModelTest
    {
        /// <summary>Test stub for MonthsAliveInPlanet(Int32, Int32, Int32)</summary>
        [PexMethod]
        public int MonthsAliveInPlanetTest([PexAssumeUnderTest]Model target, int yearBorn, int yearInTime, int monthsInPlanetsYear)
        {
            int result = target.MonthsAliveInPlanet(yearBorn, yearInTime, monthsInPlanetsYear);
            return result;
            // TODO: add assertions to method ModelTest.MonthsAliveInPlanetTest(Model, Int32, Int32, Int32)
        }
    }
