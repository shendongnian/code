    interface Iservice{
    
    bool A()
    bool B()
    
    }
    
    class ServiceImpl : Iservice {
    
    bool A(){//do something}
    
    bool B(){//do something}
    
    }
    
    class LoggedServiceImpl : Iservice{
    
    Iservice innerService:
    
    public LoggedServiceImpl(Iservice innerServ){
    
    innerService = innerServ;
    
    }
    
    public bool A(){
    
    trace("A started");
    bool res = innerService.A
    trace("A ended");
    return res
    }
    
    public bool B(){
    
    trace("B started");
    bool res = innerService.B
    trace("B ended");
    return res
    }
    
    }
    
    Iservice myService = new ServiceImpl();
    Iservice myLoggedService = new LoggedServiceImpl(Iservice);
    Console.WriteLine(Iservice.A();)
    Console.WriteLine(Iservice.B();)
