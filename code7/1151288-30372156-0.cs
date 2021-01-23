    class MyClass
    {
        private readonly IUnitOfWorkFactory _factory;
        public MyClass(IUnitOfWorkFactory factory)
        {
            _factory = factory;
        }
        public Messages addItem(Item item)
        {
            Messages resultMessage = Messages.Success;
            using (IUnitOfWork unitOfWork = _factory.GetUnitOfWork())
            {
                try
                {
                    unitOfWork.ItemRep.Insert(item);
                    unitOfWork.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    resultMessage = Messages.DB_Failure;
                }
            }
            return resultMessage;
        }
        public void Test()
        {
            // Arrange
            var factoryMock = new Mock<IUnitOfWorkFactory>();
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IItemRepository>();
            factoryMock.Setup(f => f.GetUnitOfWork()).Returns(uowMock.Object);
            uowMock.Setup(u => u.ItemRep).Returns(repositoryMock.Object);
            var sut = new MyClass(factoryMock.Object);
            // Act
            var item = new Item();
            sut.addItem(item);
            // Assert
            repositoryMock.Verify(r => r.Insert(item), Times.Once);
            uowMock.Verify(u => u.Commit(), Times.Once);
        }
    }
