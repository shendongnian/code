    Mock<IDateServer> server = new Mock<IDateServer>();
    
    const string testDateString = "2016-02-17";
    const string testCurrencyPair = "USDCAD";
    
    server.Setup(obj => obj.GetValidDate(It.IsAny<string>(), 
                                         It.IsAny<string>(), 
                                         It.IsAny<Action<string>>()))
          .Callback<string, string, Action<string>>((currencyPair, date, callback) =>
          {
                //  The parameters passed into GetValidDate (see below) 
                //  will be available in here.
                Debug.WriteLine(currencyPair);
                Debug.WriteLine(date);
          });
    
    server.Object.GetValidDate(testCurrencyPair, testDateString, null);
