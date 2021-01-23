    [Test]
    public async Task TestReturnsPagedCalculationResults()
    {
    	//Arrange
    	var financialYear = _fixture.Create<int>();
    	var pagedResults = _fixture.Create<PagedResults<ColleagueCalculationResult>>();
    	_connection.QueryAsync(null, null, null).ReturnsForAnyArgs(Task.FromResult(pagedResults));
    
    	//Act
    	var result = await _calculationResultsRepository.PagedListAsync(financialYear);
    
    	//Assert
    	Assert.IsInstanceOf<PagedResults<ColleagueCalculationResult>>(result);
    }
