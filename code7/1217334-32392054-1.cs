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
            Console.WriteLine("Interface implementation");
        }
        //You can implement interface method using next signature
        void Iinterface.printMyName()
        {
            Console.WriteLine("Abstract class implementation");
        }
    }
