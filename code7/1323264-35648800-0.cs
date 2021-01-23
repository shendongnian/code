    static void Main(string[] args)
        {
            setget sgobj = new setget();
            login _login = new login();
            sgobj = _login.header_message();
            Console.WriteLine(sgobj.heading);
            Console.ReadKey();
        }
        class setget
        {
            public string heading
            { set; get; }
        }
        class login
        {
            setget setobj = new setget();
            public setget header_message()
            {
                setobj.heading = "*************************************************************************************" +
                    "\n*************************************************************************************" +
                    "\n*************************                             *******************************" +
                    "\n************************* Welcome to Radeon Limited.. *******************************" +
                    "\n*************************                             *******************************" +
                    "\n*************************************************************************************" +
                    "\n*************************************************************************************";
                return setobj;
            }
        }
