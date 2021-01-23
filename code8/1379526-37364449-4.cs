    using System;
    class Program
    {
        static void Main(string[] args)
        {
    	   if (args != null)
    	   {
    	    for (int i = 0; i < args.Length; i++) // Loop through array or command line parameters
    	    {
    		    string argument = args[i];
                MessageBox.Show(argument);
    	    }
    	  }
        }
    }
