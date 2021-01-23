    //ARRANGE
    bool patAdded = false;
    PaymentAttemptTrace pat = null; //will assign a value to this when adding new entity
    var mockSetPaymentAttemptTrace = new Mock<DbSet<PaymentAttemptTrace>>();
    //setup a call back on Add to get the entity that was added to dbset
    mockSetPaymentAttemptTrace
        .Setup(m => m.Add(It.IsAny<PaymentAttemptTrace>()))
        .Callback((PaymentAttemptTrace arg) => {
            pat = arg;
            padAdded = (pat != null);
        });
    var mockContext = new Mock<PublicAreaContext>();
    mockContext.Setup(m => m.Set<PaymentAttemptTrace>()).Returns(mockSetPaymentAttemptTrace.Object);
    mockContext.Setup(x => x.SaveChanges()).Returns(1);//for when you save the added entity
    //Here I create a fake request 
    TracePaymentAttemptRequest request = new TracePaymentAttemptRequest();
    
    ... 
    
    //I call the facade. The facade create a PaymentAttemptTrace and insert it in the mocked db
    ToolsFacade facade = new ToolsFacade(mockContext.Object);
    //ACT
    TracePaymentAttemptResponse response = facade.TraceAutoPayPaymentAttempt(request);
    
    //ASSERT
    Assert.IsTrue(response.Result == it.MC.WebApi.Models.ResponseDTO.ResponseResult.Success);
    
    mockSetPaymentAttemptTrace.Verify(m => m.Add(It.IsAny<PaymentAttemptTrace>()), Times.Once());
    mockContext.Verify(m => m.SaveChanges(), Times.Once());
    Assert.IsTrue(patAdded);
    Assert.IsTrue(pat.AttemptDate == new DateTime(2016, 07, 27, 11, 46, 24));
