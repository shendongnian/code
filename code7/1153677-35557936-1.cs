        [Test]
        public async Task QueryTest()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ... },
                new Product { ... }
            };
            var db = new InMemoryDatabase();
            db.Insert(products);
            connectionFactoryMock.Setup(c => c.GetConnection()).Returns(db.OpenConnection());
            // Act
            var result = await new ProductRepository(connectionFactoryMock.Object).GetAll();
            // Assert
            result.ShouldBeEquivalentTo(products);
        }
