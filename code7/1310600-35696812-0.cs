         public class Client : IClient
         {
            public string funcA()
            {
                var output = funcB(1);
                //Do something on output and produce finalResult
                var finalResult = "B result: " + output;
                return finalResult;
            }
        
            public string funcB(int x)
            {
                // Some operations on produces string result
                return "result";
            }
        }
        
        [TestMethod, Isolated]
        public void TestMethod()
        {
            //Arrange
            var foo = new Client();
            Isolate.WhenCalled(() => foo.funcB(0)).WillReturn("test");
        
           //Act
           var output = foo.funcA();
        
           //Assert
           Assert.AreEqual("B result: test", output);
       }
