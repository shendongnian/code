    public abstract class AbClass
    {
        public abstract void printMyName();
    }
    internal interface Iinterface
    {
        void printMyName();
    }
    public class MainClass : AbClass, Iinterface
    {
        //how this methods will be implemented here??? 
        public override void printMyName()
        {
            throw new NotImplementedException();
        }
    }
