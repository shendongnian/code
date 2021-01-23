    public void InSafeApiContext(Action action)
    {
      if (api.Versions < "2.5.3")
        throw new Exception("Not supported, please update");
      action.Invoke();      
    }
    public void apiStuff(Data input)
    {
      InSafeApiContext(doApiStuff(input));
    }
