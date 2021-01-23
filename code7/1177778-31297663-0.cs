    // Arrange
    var mockResp = MockRepository.GeneratePartialMock<WebResponse>();
    var responseData = Encoding.UTF8.GetBytes("my XML here");
    var stream = new MemoryStream(responseData);
    mockResp.Expect(x => x.GetResponseStream()).Return(stream);
    
    var mockReq = MockRepository.GeneratePartialMock<WebRequest>();
    mockReq.Expect(x => x.GetResponse()).Return(mockResp);
    
    // Act
    // test here!
    
    // Assert
    mockReq.VerifyAllExpectations();
    mockResp.VerifyAllExpectations();
