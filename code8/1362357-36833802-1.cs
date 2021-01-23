    public abstract class BaseUnit{
      
       public void virtual DoSomething(){
             // some default code
       }     
    }
    public class MyUnitType : BaseUnit{
      public override void DoSomething(){
         // my custom code if I do no want the default logic
      }
    }
