    public class test 
    {
     private static AutoResetEvent event_2 = new AutoResetEvent(false);
     
     public void uploadfile()
     {
       ///do file updating 
       //than give signale 
       event_2.set();
     }
      
     public void deletefile()
     {
        event_2.WaitOne();
        //delete file 
     }
    }
