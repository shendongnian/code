    public class Default1ControllerTests
    {
        private Mock<Default1Controller> controllerMock;
        [SetUp]
        public void SetUp()
        {
            this.controllerMock = new Mock<Default1Controller>() { CallBase = true };
            this.controllerMock.Setup(m => m.PopulatePageCombos(It.IsAny<int?>())).Callback(() => { });
        }
        [Test]
        public void Can_Open_SomeAction()
        {
            // controller is already set inside `SetUp` unit step.
            ViewResult res = this.controllerMock.Object.SomeAction(null) as ViewResult;
            var model = res.Model as MyModel;
            Assert.IsNotNull(model);
        }
    }
