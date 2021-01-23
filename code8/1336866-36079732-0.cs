    public class TargetControllerTests
    {
        
        private readonly Mock<ITargetRepository> _targetRepository;
        private readonly TargetController _controller;
    
        public TargetControllerTests()
        {
            _targetRepository = new Mock<ITargetRepository>();
            this._controller = new TargetController(_targetRepository.Object);
        }
    
        [Fact()]
        public void IndexActionResultTest()
        {
            ViewResult vr = this._controller.Index() as ViewResult;
            Assert.NotNull(vr);
            Assert.Equal("Index", vr.ViewName);
        }
    }
