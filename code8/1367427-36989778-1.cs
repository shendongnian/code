    public class BaseClass{
        public abstract void method(){ return 0; }
        public void concrete(){ method(); }
    }
    
    public class OverClass : BaseClass{
        public override void method(){
            // some code
            return 2;
        }
    }    
    
    //You can call concrete like that:
    instanceOverClass.concrete();
    instanceBaseClass.conctere();
