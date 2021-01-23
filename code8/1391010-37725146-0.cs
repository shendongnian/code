    [TestClass]
    public class MatchControllerTests
    {
        private readonly MatchController _sut;
		private readonly IMatchService _matchService;
		public MatchControllerTests()
		{
			_matchService = MockRepository.GenerateMock<IMatchService>();
			_sut = new ProductController(_matchService);
		}
		[TestMethod]
		public void DoSomething_WithCertainParameters_ShouldDoSomething()
		{
            _matchService
                   .Expect(x => x.GetMatches(Arg<string>.Is.Anything))
                   .Return(new []{new Match()});
			_sut.DoSomething();
			_matchService.AssertWasCalled(x => x.GetMatches(Arg<string>.Is.Anything);
		}
