    class YourLogicClass{
       List<YourClass> characters= new List<YourClass>();
       private timer;
       List<TimerControlled> timerControlledObjects = new List<TimerControlled>();
       ...
       public void Initialize(){
          ... //your code, character creation and such
          foreach(YourClass character in characters){ //do the same with all objects that have TimerControlled interface implemented
             timerControlledObjects.add(character);
          }
          timer = new Timer();
          timer.Tick += new EventHandler(timerTick)
          timer.Start();
          
       } 
    
       public void timerTick(Object sender, EventArgs e){
          foreach(TimerControlled timerControlledObject in timerControlObjects){
             timerControlledObject.TimerTick();
          }
       }
    
    }
