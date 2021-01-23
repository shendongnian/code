    using System;
    
    static partial class Program
    {
        static void Main()
        {
            Server svr = new Server();
    
            Client cl1 = new Client("123");
            Client cl2 = new Client("456");
            Client cl3 = new Client("789");
    
            //Register
            cl1.ClientRegister(svr);
            cl2.ClientRegister(svr);
            cl3.ClientRegister(svr);
    
            svr.SendMessage("message from server");
    
            //Unregister    
            cl1.ClientUnregister(svr);
            cl2.ClientUnregister(svr);
            cl3.ClientUnregister(svr);
    
            Console.ReadLine();
        }
    }
