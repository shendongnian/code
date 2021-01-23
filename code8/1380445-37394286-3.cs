    static bool CreateAll(object1 obj1, object2 obj2)
    {
         // Policy to retry 3 times, waiting 5 seconds between retries.
         var policy =
             Policy
                  .Handle<SqlException>()
                  .WaitAndRetry(3, count =>
                  {
                     return TimeSpan.FromSeconds(5); 
                  });
    
           policy.Execute(() => UpdateDatabase1(obj1));
           policy.Execute(() => UpdateDatabase2(obj2));
      }
