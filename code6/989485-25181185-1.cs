    //Moq
    _mock.Verify(x=>x.method());
    It.IsAny<string>()
    //FIE
    A.CallTo(x=>x.method()).MustHaveHappened();
    A<string>.Ignored // or A<string>._
