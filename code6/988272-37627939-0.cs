    static void Main(string[] args)
    {
            String mutexName = "MyApplication" + 
            System.Security.Principal.WindowsIdentity.GetCurrent().User.AccountDomainSid;
            Boolean createdNew;
            Mutex mutex = new Mutex(true, mutexName, out createdNew);
            if (!createdNew)
            {
                //If createdNew is false that means an instance of application is already running for this   
                // user.
                //So in this case stop the application from executing.
                return;
            }
            Console.ReadKey();
    }
