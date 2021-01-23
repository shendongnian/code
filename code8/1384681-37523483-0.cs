     public T MyMethod<T>(string url, string userName, string userPassword) {
           var myService = Activator.CreateInstance(typeof(T));
          System.Reflection.PropertyInfo URL = myService.GetType().GetProperty("Url");
          System.Reflection.PropertyInfo NetworkCred = myService.GetType().GetProperty("Credentials");
          URL.SetValue(myService, url, null);
          NetworkCred.SetValue(myService, new System.Net.NetworkCredential(userName, userPassword), null);
          return (T)myService;
       }
