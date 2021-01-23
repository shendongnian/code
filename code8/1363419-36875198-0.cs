    [Test]
    public async Task DoLogonCommandTest()
    {
        AsyncContext.Run(() =>
        {
            //Arrange
            ViewModel vm = new ViewModel(clubCache, authorisationCache, authorisationService);
    
            //Act
            await Task.Run(() => vm.GetAuthorisationToken.Execute(null));
        });
    
        //Assert
        Assert.Greater(MockDispatcher.Requests.Count, 0);
    }
