    // first call
    _someServiceMock.Verify(x => x.SubmitRequest(It.Is<RequestObj>(
        o => o.SomeOtherProp), Times.Once());
    // second call
    _someServiceMock.Verify(x => x.SubmitRequest(It.Is<RequestObj>(
        o => o.SomeProp == "New Value" && !o.SomeOtherProp), Times.Once());
