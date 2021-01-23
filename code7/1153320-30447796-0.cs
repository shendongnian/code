    static void Main(string[] args)
    {
        if (Environment.UserInteractive)
        {
            MyNewService service1 = new MyNewService(args);
            service1.TestStartupAndStop(args);
        }
        else
        {
            // Put the body of your old Main method here.
        }
    }
