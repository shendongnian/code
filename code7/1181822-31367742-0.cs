    [Test]
    public void TestCountryIsUpdatedWhen….() {
      var countryBLL = Substitute.For<ICountryBLL>();
      // setup specific countries to return:
      countryBLL.GetAllCountries().Returns( someFixedListOfCountries );
      var subject = new MyClassBeingTested(countryBLL);
      subject.LogicForUpdatingAndInsertingCountries…();
      countryBLL.Received().UpdateCountry(…);
    }
