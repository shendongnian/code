    public class FooBusinessTest
    {
        _mockedBarDataHandler = new Mock<IBarDataHandler>(){CallBase:true};
        public FooTestMeth()
        {
            //Arrange
            _mockedBarDataHandler.Setup(x => x.Search(It.IsAny<int>).Returns(1);
        
            FooBusiness fooBusiness = new FooBusiness();
            fooBusiness.BarDatahandler = _mockedBarDataHandler.Object;
            //Act
        }
    }
