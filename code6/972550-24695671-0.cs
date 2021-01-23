    public void SomeMethod()
    {
      svc.GetNameCompleted += GetUserNameCompleted;
      svc.GetNameAsync(ordercode);
    }
    
    public void GetUserNameCompleted(whatever the signature is)
    {
      string name = MyName;
    }
