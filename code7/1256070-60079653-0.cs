        [TestMethod]
        public void GetPersonalList_NoContent_Ok()
        {
        
        var serviceresponse = new yourresponseobject<yourmodel>{
        Message = "what ever response";
        Data = null;
        
        };
        
        var service = new Mock<youserviceInterface>(MockBehavior.Strict);
                    service.Setup(x => x.GetPersonalList()(It.IsAny<string>())).ReturnsAsync(serviceResponse); /// for number of parameters in controller method, add It.IsAny<string>() 
            //Arrange
            _facade.Setup(x => x.Get(_userContext.Object.GetPersonnelNumber(), null)).Returns((PersonalExpensesReport)null);
        
            //Act
            var result = _controller.GetPersonalList();
        
            //Assert
            var negociatedResult = result as Object;
            Assert.IsNotNull(result.value);
    Assert.AreEqual(200,result.negociatedResult.statuscode);
    
            
        }
