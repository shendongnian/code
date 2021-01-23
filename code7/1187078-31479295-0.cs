    public abstract class Task {
    public abstract void ExecuteTask ();
    public virtual void PauseTask() {Console.WriteLine ("Task Paused")}
    public virtual void StopTask() {Console.WriteLine ("Task Stopped")}
    }
    public class Lunch : Task {
       public override void ExecuteTask ()
       {
         Console.WriteLine ("Lunch Task Started");
       }
    }
    public class ObjectCollection{
        Dictionary<string,Task> objectStringMapper= new Dictionary<string,string>();
        Dictionary<string,Task> objectTimeMapper= new Dictionary<string,string>();
        public ObjectCollection(){
            objectMapper.Add("Lunch",new LunchTask());
            objectTimeMapper.Add(12,new LunchTask());        
        }
        public Task getObject(string objId){
            return objectMapper.get(objId);
        }
        public Task getObject(int time){
            return objectTimeMapper.get(time);
        } 
     }
    public class Human {
        ObjetCollection objectsFactory = new ObjectCollection();
        void ToBeCalledEveryHour () {
            int hour = someHour();
            if (attributions.ContainsKey(hour))
                objectsFactory.getObject(hour).ExecuteTask();
          }
    }
