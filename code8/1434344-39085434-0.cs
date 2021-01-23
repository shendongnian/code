        [Test]
        public void TupleTest()
        {
            var result = _connection.Query<int, decimal, Tuple<int, decimal>>
                ("select 1 as Id, 12.99 as ContainerPrice", Tuple.Create, splitOn: "*")
                .FirstOrDefault();
            Assert.That(result.Item1, Is.EqualTo(1));
            Assert.That(result.Item2, Is.EqualTo(12.99));
        }
