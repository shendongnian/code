        [TestMethod]
        public void FromLocalPointsParallel()
        {
            var loop = new int[10];
            Parallel.ForEach(
                loop,
                item =>
                    {
                        var projectedCoordinates = this.ConvertToLocalPoints();
                        foreach (var projectedCoordinate in projectedCoordinates)
                        {
                            var x = projectedCoordinate.X;
                            var y = projectedCoordinate.Y;
                            Assert.IsFalse(double.IsInfinity(x) || double.IsNaN(x), "Projected X is not a valid number");
                            Assert.IsFalse(double.IsInfinity(y) || double.IsNaN(y), "Projected Y is not a valid number");
                        }
                    });
        }
