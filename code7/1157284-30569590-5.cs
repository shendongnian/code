    class Program
    {      
        static void main()
        {
             var telnet = new TelnetConnection();
             string s = ""; 
             telnet.Login("some username", "some password", 123, ref s);
             //s is altered here
        }
     }
