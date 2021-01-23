    //your windows service
    public class RunningInstance : ServiceBase
        { 
           //this will  be outscope of method start and WebbApp will  not disposed 
           static IDisposable signalRApp;
           //and in your onstart   
    
            protected override void OnStart(string[] args)
            {
                  
                 signalRApp=WebApp.Start<Startup>(this._signalRURL);
            }
             
        }
       
     
