    class Program
    {
        static void Main(string[] args)
        {
            SetGet sgobj = new SetGet();
            // pass your SetGet object to the login constructor
            Login login = new Login(sgobj);
            // call the method to set the login message
            login.header_message();
            // print the login message
            Console.WriteLine(sgobj.Heading);
            Console.ReadKey();
        }
    }
    class SetGet
    {
        public string Heading
        { set; get; }
    }
    class Login
    {
        private SetGet setobj;
        // accept a SetGet object and store it in the login instance
        public Login (SetGet setobj)
        {
            this.setobj = setobj;
        }
        public void header_message()
        {
            setobj.Heading= "*************************************************************************************"+
                "\n*************************************************************************************"+
                "\n*************************                             *******************************"+
                "\n************************* Welcome to Radeon Limited.. *******************************"+
                "\n*************************                             *******************************"+
                "\n*************************************************************************************"+
                "\n*************************************************************************************";
        }
    }
