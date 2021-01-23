    public static class Global{
    //I usually create such class for global settings
       public static Timer timer= new Timer();
    }
    class YourLogicClass{
       public void Initialize(){
           ... 
           Global.timer.Start();
       }
    }
    class YourClass{
       
       public YourClass(){
          Global.timer.tick += new EventHandler(timerTick);
       }
    
    
       private void timerTick(Object sender,EventArgs e){
          advanceCooldowns();
          advanceBuffTimers();
       }
    }
