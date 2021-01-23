    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication6
    {
    	static class Program
    	{
    		/// <summary>
    		/// The main entry point for the application.
    		/// </summary>
    		[STAThread]
    		static void Main(string[] args)
    		{
    			foreach (var arg in args)
    			{
    				MessageBox.Show(arg);
    			}
    
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			Application.Run(new Form1());
    		}
    	}
    }
