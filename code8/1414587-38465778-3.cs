    [TestMethod]
    public async Task Moq_Setup_Should_Return_List_Of_Objects() {
        var mockList = new List<IBillItem>
        {
            new BillItem
            {
                Id = 0,
                DueDate = DateTime.Today,
                Name = "User",
                IndexNumber = "",
                AccountNumber = "",
                Amount = decimal.One
            },
            new BillItem
            {
                Id = 1,
                DueDate = DateTime.Today.AddDays(1),
                Name = "User",
                IndexNumber = "",
                AccountNumber = "",
                Amount = decimal.One
            }
        };
        string name = "User";
        var _settingsService = new Mock<ISettingsService>();
        _settingsService
            .Setup(m => m.Name)
            .Returns(name);
        _settingsService
            .Setup(m => m.LoggerUserName)
            .Returns(name);
        var _billHandlingService = new Mock<IBillHandlingService>();
        _billHandlingService
            .Setup(x => x.GetAllBillsAsync(It.IsAny<string>()))
            .ReturnsAsync(mockList);
        var listBillsVm = new ListBillsViewModel(_billHandlingService.Object, _settingsService.Object);
        await listBillsVm.GetBillsAsync();
        _billHandlingService.Verify(x => x.GetAllBillsAsync(_settingsService.Name), Times.AtMostOnce);
        Assert.AreEqual(1, listBillsVm.BillsList.Count);
    }
