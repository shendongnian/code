      try
      {
         Deposit_Money(merchant); // this method invokes an exception
      }
      catch (Exception e)
      {
          Assert.Fail(); /// Explicitly fail the test
          CleanUp();
      }
