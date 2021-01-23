    class Program
    {
        static void Main(string[] args)
        {
            UsesDelegates usesDelegates = new UsesDelegates();
            usesDelegates.GetDelegate(Console.WriteLine);
            usesDelegates.CallDelegate();
        }
    }
