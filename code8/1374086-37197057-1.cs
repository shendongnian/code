    internal interface ITest
    {
        virtual void GetData(string spname);
    }
    internal class Test : ITest
    {
        public void GetData(string spname)
        {
            Console.WriteLine("Executing store proc: " + spname);
        }
    }
