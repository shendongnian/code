        [TestMethod]
        public void TestEmptyGeometry()
        {
            var shape = new TestShapeModel { GeometryData = null };
            _shapeViewModel = new Shape(shape);
            var actual = _shapeViewModel.Geometry;
            Assert.IsTrue(actual.IsEmpty());
        }
