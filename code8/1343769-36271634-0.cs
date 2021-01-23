    //Arrange
    Mock<IView> moq = new Mock<IView>();
    var textbox = new TextBox();
    moq.Setup(x => x.MyTextBox).Returns(textbox);
    Presenter presenter = new Presenter(moq.Object);
    
    //Act
    presenter.Foo("test");
    //Assert
    Assert.AreEqual("test", textbox.Text);
