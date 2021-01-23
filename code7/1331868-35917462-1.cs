    [WebMethod()]
    public static Service_Response GetHelloWorld() {
          return new Service_Response("hello world", true);
    }
    //or
    [WebMethod()]
    public static Service_Response GetHelloWorld(int i) {
          return new Service_Response("hello world" + i);
    }
    //or
    [WebMethod()]
    public static Service_Response GetHelloWorld(string name) {
          var data = DateTime.Now;
          return new Service_Response("hello world from " + name, data);
    }
