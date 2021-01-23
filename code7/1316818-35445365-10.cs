    [Test]
    public void ShutDown_Nicely_Should_Pass()  {
        mockCore.Setup(m => m.ShutDown(true).Returns(ReactorStatus.Ok));
        var status = reactor.ShutDown(true);
        status.Should().Be(ReactorStatus.Ok);
        mockCore.VerifyAll();
    }
    [Test]
    public void ShutDown_Badly_Should_Fail()  {
        mockCore.Setup(m => m.ShutDown(false).Returns(ReactorStatus.OhDear));
        var status = reactor.ShutDown(false);
        status.Should().Be(ReactorStatus.OhDear);
        mockCore.VerifyAll();
    }
