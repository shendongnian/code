     public static void DoSomethingThatThrowsException()
     {
         var ex = new MyException(Enumerable.Range(1, 4)
                                  .Select(e => new MyError() 
                                               { 
                                                  Message = "error " + e.ToString() 
                                               })
                                  .ToList());
         throw ex;
     }
