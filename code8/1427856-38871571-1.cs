    [TestFixture]
    public class UsingReturnValue
    {
      [Test]
      public async Task TestException()
      {
        MyException ex = Assert.ThrowsAsync<MyException>(async () => await MethodThatThrows());
    
        Assert.That( ex.Message, Is.EqualTo( "message" ) );
        Assert.That( ex.MyParam, Is.EqualTo( 42 ) ); 
      }
    }
