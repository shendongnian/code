    [TestClass]
    public class GeometryTests
    {
        [TestMethod]
        public void TestTwoEmptyGeometries()
        {
            var geometry1 = Geometry.Empty;
            var geometry2 = Geometry.Empty;
            // Pass
            Assert.AreEqual(geometry1, geometry2);
        }
    }
