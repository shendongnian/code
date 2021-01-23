        [TestMethod]
        public void TestEmptyGeometry()
        {
            var shape = new TestShapeModel { GeometryData = null };
            _shapeViewModel = new Shape(shape);
            var expected = Geometry.Empty;
            var actual = _shapeViewModel.Geometry;
            Assert.AreEqual(expected, actual);
        }
