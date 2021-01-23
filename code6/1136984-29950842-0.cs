    public class TriggerableObject 
    {
        public virtual Trigger(){
            DoSomething();
        }
    }
    public class X : TriggerableObject
    {
        public override Trigger(){
            DoSomethingElse();
        }
    }
    public class X2 : TriggerableObject
    {
        public override Trigger(){
            DoSomethingOther();
        }
    }
    public class Trigger
    {
        TriggerableObject obj = FindMyObject();
        obj.Trigger();
    }
