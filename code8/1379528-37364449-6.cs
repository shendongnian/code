    static class Program
    {
        [STAThread]
        static void Main()
        {
           if (args != null)
    	   {
    	    for (int i = 0; i < args.Length; i++) // Loop through array or command line parameters
    	    {
    		    string argument = args[i];
                //MessageBox.Show(argument);
    	    }
    	  }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            var application = new WindowsFormsApplication();
            application.Run(new Form1(argument)); //<-- see here is how I pass it
        }
    }
