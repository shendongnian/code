    using System;
    using System.Windows.Forms;
    
    namespace TreeViewDemo
    {
    	public partial class ConnectForm : Form
    	{
    		Form parent; // a reference of the main form
    		
    		public ConnectForm(Form form)
    		{
    			InitializeComponent();
    			
    			// set a reference of the main form
    			parent = form;
    		}
    		
    		void Button1Click(object sender, EventArgs e)
    		{
    			// you have to cast it to the MainForm first,
    			// otherwise the method SetFtpClient is not accessible
    			var _main = (MainForm) parent;
    			_main.SetFtpClient();
    		}
    	}
    }
