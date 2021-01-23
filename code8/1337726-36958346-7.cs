    [TestClass]
    public class MockDbSetTests {
        private List<StubEntity> _data;
        private Repository<StubEntity> _repository;
        [TestInitialize]
        public void TestInitialize() {
            _data = new List<StubEntity>
            {
                new StubEntity {Id = 1, Name = "Entity 1"},
                //...
            };
            var mockDbSet = _data.AsDbSetMock();
            var context = new Mock<StubContext>();
            context.Setup(x => x.DbEntities).Returns(mockDbSet.Object);
            context.Setup(x => x.Set<StubEntity>()).Returns(mockDbSet.Object);
            _repository = new Repository<StubEntity>(context.Object);
        }
        [TestMethod]
        public void Find_Should_Return_Proper_Entity() {
            //Act
            var entity = _repository.Find(s => s.Id == 1);
            //Assert
            Assert.IsNotNull(entity);
            Assert.IsTrue(entity.Count() == 1);
        }
    }
