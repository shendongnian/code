    [Test]
    public void View_Display_List()
    {
       //Arrange
       _view = MockRepository.GenerateMock<IView>();
       List<Bundle> objTest = new List<Bundle>();
       controller = new Presenter(_view);
       //Act
       _controller.Bind();
       //Assert
       Assert.IsNotNull(_view.DisplayList );
    } 
