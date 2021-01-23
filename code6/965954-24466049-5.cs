    class Program
    {
        static void Main(string[] args)
        {
            Apply a = new Apply(); //I will create if I dont need any logic but be able to get AB's behavior, I will call that class NoApply
            Helper(a);
         
        }
        static void Helper(AB myobj)
        {
            myobj.CanGetDataTable();
        }
    }
    class AB
    {
        IGetDataTable gtb;
    
        public virtual void LogicSetter(IGetDataTable dt)
        {
            gtb = dt;
        }
    
        public void CanGetDataTable()
        {
            this.gtb.GetDataTable();
        }
        public void DoSameThingBothAB()
        {
            Console.WriteLine("do same things");
        }
    }
    
    class Apply:AB
    {
        public Apply()
        {
            base.LogicSetter(new LogicForA());
        }
    }
    public interface IGetDataTable
    {
        void GetDataTable();
    }
    public class LogicForA:IGetDataTable
    {
        public void GetDataTable()
        {
            Console.WriteLine("logic for A");
        }
    }
    public class LogicForB:IGetDataTable
    {
        public void GetDataTable()
        {
            Console.WriteLine("logic for B");
        }
    }
    public class LogicforFutured:IGetDataTable
    {
        public void GetDataTable()
        {
            Console.WriteLine("logic for object created in 2019");
        }
    }
