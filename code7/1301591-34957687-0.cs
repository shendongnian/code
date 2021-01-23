        [Test]
        public void SearchforAccount_ReturnSearchAccount()
        {
            //Arrange
            var mockAccountsManager = A.Fake<IAccountsManager>();
            var mockCallerInfoManager = A.Fake<ICallerInfoManager>();
            const string SearchTerm = "google"; // Use the passed in parameter in the CallTo setup
            //Define search parameter
            AccountRequest mockAccountRequest = new AccountRequest
            {
                SearchTerm = SearchTerm
            };
            List<Account> expected = new List<Account> { new Account() }; // What we expect to get back
            A.CallTo(() => mockAccountsManager.GetAllWithNameContaining(SearchTerm, A<string>.Ignored)).Returns(expected); // mock the call made in the controller
            using (var accountsController = new AccountController2(mockAccountsManager, mockCallerInfoManager))
            {
                //Act
                List<Account> returnedAccounts = accountsController.Search(mockAccountRequest);
                
                //Assert
                Assert.AreSame(expected, returnedAccounts);
            }
        }
