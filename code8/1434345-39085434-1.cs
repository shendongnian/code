        [Test]
        public void DynamicTest()
        {
            var result = _connection.Query<dynamic>
                ("select 1 as Id, 12.99 as ContainerPrice")
                .FirstOrDefault();
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.ContainerPrice, Is.EqualTo(12.99));
        }
