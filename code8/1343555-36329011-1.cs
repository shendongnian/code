    public class Foo
    {
        public void ReadBlock()
        {
            var block = new CloudBlockBlob(new Uri("http://myUrl/%2E%2E/%2E%2E"));
            var name = block.Name;
        }
    }
    
    [TestMethod, Isolated]
    public void TestReadBlock()
    {
        //Arrange
        var fakeBlock = Isolate.Fake.AllInstances<CloudBlockBlob>();
        Isolate.WhenCalled(() => fakeBlock.Name).WillReturn("Name");
        
       //Act
       var foo = new Foo();
       foo.ReadBlock();
        
       //Assert
       Isolate.Verify.WasCalledWithAnyArguments(() => fakeBlock.Name);
    }
