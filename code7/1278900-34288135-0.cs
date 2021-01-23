    class Container
    {
      public object container;
    }
    struct Params
    {
      ...
      Container xxx;
    }
    Params params = new Params();
    params.xxx = new Container();
    void Callback(object response, object param)
    {
      var data = (Params)param;
      data.xxx.container = (XXX[])response;
      // signal
    }
