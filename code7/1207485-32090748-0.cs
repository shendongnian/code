    private void SomeMethod()
    {
      int userId 0;
      string userProperty = GetUserProperty("UserId", "0");
      if(int.TryParse(userProperty , out userId)){
          // Do something with userId..
      }
      else{
        //Do something with the exception
          Console.Write("Invalid property value {0}", userProperty);
      }
    }
