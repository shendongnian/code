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
            Console.WriteLine("Abstract class implementation");
        }
        //You can implement interface method using next signature
        void Iinterface.printMyName()
        {
            Console.WriteLine("Interface implementation");
        }
    }
    public class MainClass_WithoutExplicityImplementation : AbClass, Iinterface
    {
        //how this methods will be implemented here??? 
        public override void printMyName()
        {
            Console.WriteLine("Abstract class and interface implementation");
        }
    }
