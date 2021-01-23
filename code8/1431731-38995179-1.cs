    private IFixture _fixture;
    private IInsightDatabase _insightDatabase;
    private CalculationResultsRepository _calculationResultsRepository;
    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture().Customize(new AutoConfiguredNSubstituteCustomization());
        _insightDatabase = _fixture.Freeze<IInsightDatabase>();
        _calculationResultsRepository = _fixture.Create<CalculationResultsRepository>();
    }
    [Test]
    public async Task PagedListAsync_ReturnsPagedResults()
    {
        //Arrange
        var financialYearId = _fixture.Create<int>();
        var pagedResults = _fixture.Create<PagedResults<ColleagueCalculationResult>>();
        _insightDatabase.QueryAsync(Arg.Any<string>(), Arg.Any<object>(), Arg.Any<IQueryReader<PagedResults<ColleagueCalculationResult>>>()).Returns(pagedResults);
        //Act
        var result = await _calculationResultsRepository.PagedListAsync(financialYearId);
        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<PagedResults<ColleagueCalculationResult>>();
        result.Should().Be(pagedResults);
    }
