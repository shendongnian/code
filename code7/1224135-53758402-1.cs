    public interface IFoo
    {
        bool foo(int n);
    }
    
    public interface IBar
    {
        int bar(string a);
    }
    
    [Test]
    public void SequenceVerifyer_with_full_sequence()
    {
        var fooMock = new Mock<IFoo>(MockBehavior.Strict);
        var barMock = new Mock<IBar>(MockBehavior.Strict);
        var seq = new SequenceVerifyer();
    
        fooMock.Setup(f => f.foo(3)).Returns(false);
        barMock.Setup(b => b.bar("world")).Returns(4);
    
        fooMock.InSequence(seq.Sequence).Setup(f => f.foo(4)).Returns(true).Callback(seq.NextCallback());
        barMock.InSequence(seq.Sequence).Setup(b => b.bar("hello")).Returns(2).Callback(seq.NextCallback());
        fooMock.InSequence(seq.Sequence).Setup(f => f.foo(4)).Returns(false).Callback(seq.NextCallback());
    
        fooMock.Object.foo(3); //non sequence
        fooMock.Object.foo(4);
        barMock.Object.bar("hello");
        barMock.Object.bar("world"); //non sequence
        fooMock.Object.foo(4);
    
        fooMock.VerifyAll();
        barMock.VerifyAll();
        seq.VerifyAll();
    }
