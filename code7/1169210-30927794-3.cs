    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 myForm = new Form1(); //create the object here
            //you can work with the form here
            Application.Run(myForm); //pass in the form
        }
    }
