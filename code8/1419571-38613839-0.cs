	var mockContext = new Mock<PublicAreaContext>();
	//Here I mock the entity I cannot get the correct values
	List<PaymentAttemptTrace> pat = new List<PaymentAttemptTrace>();
    var mockSetPaymentAttemptTrace = new Mock<DbSet<PaymentAttemptTrace>>();
    mockSetPaymentAttemptTrace.Setup(m => m.Add(It.IsAny<PaymentAttemptTrace>())).Callback<PaymentAttemptTrace>(list.Add);
    mockContext.Setup(m => m.Set<PaymentAttemptTrace>()).Returns(mockSetPaymentAttemptTrace.Object);
            
    mockContext.Setup(x => x.SaveChanges()).Returns(1);
	//Here I create a fake request 
	TracePaymentAttemptRequest request = new TracePaymentAttemptRequest();
	... 
	//I call the facade. The facade create a PaymentAttemptTrace and insert it in the mocked db
	ToolsFacade facade = new ToolsFacade(mockContext.Object);
	TracePaymentAttemptResponse response = facade.TraceAutoPayPaymentAttempt(request);
	//All asserts are ok, except the last one. The date remain "empty", even if is valorized correctly during the execution of the code (I have checked in debug)
	Assert.IsTrue(response.Result == it.MC.WebApi.Models.ResponseDTO.ResponseResult.Success);
	mockSetPaymentAttemptTrace.Verify(m => m.Add(It.IsAny<PaymentAttemptTrace>()), Times.Once());
	mockContext.Verify(m => m.SaveChanges(), Times.Once());
	Assert.IsTrue(pat[0].AttemptDate == new DateTime(2016, 07, 27, 11, 46, 24));
