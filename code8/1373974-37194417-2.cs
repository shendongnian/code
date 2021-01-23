     public void SmokeTest()
     {
         var substitute = Substitute.For<IBluetoothService>();
         substitute.GetData().Returns(1);
         // Swap true with false and test will fail.
         substitute.SendData(Arg.Any<object>()).Returns(true);
         var sut = new Logger(substitute);
         try
         {
             sut.LogData("Some data to log");
         }
         catch (ArgumentException ex)
         {
                Assert.Fail(ex.Message);
         }
     }
