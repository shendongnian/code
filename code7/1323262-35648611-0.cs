    namespace rd
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                login _login = new login();
                _login.header_message();
                Console.WriteLine(_login.setobj.heading);
                Console.ReadKey();
            }
        }
    
        public class setget
        {
            public string heading
            { set; get; }
        }
    
        public class login
        {
            public setget setobj = new setget();
            public void header_message()
            {
                setobj.heading= "*************************************************************************************"+
                    "\n*************************************************************************************"+
                    "\n*************************                             *******************************"+
                    "\n************************* Welcome to Radeon Limited.. *******************************"+
                    "\n*************************                             *******************************"+
                    "\n*************************************************************************************"+
                    "\n*************************************************************************************";
            }
        }
        }
