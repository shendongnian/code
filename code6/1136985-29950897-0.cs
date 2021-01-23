    public interface ITriggerableObject 
    {
        Trigger();
    }
    public class X : ITriggerableObject 
    {
        Trigger(){
            DoSomethingElse();
        }
    }
    public class X2 : ITriggerableObject 
    {
        Trigger(){
            DoSomethingOther();
        }
    }
    public class Trigger
    {
        ITriggerableObject obj = FindMyObject();
        obj.Trigger();
    }
