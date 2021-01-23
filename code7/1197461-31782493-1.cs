    using System;
    using System.Windows.Forms;
    
    namespace TreeViewDemo
    {
    	public partial class MainForm : Form
    	{
    		public MainForm()
    		{
    			InitializeComponent();
    		}
    		
    		void Button1Click(object sender, EventArgs e)
    		{
    			// create an instance of child form, and pass the main form into it
    			var _ConnectForm = new ConnectForm(this);
    			
    			_ConnectForm.StartPosition = FormStartPosition.CenterParent;
    			_ConnectForm.ShowDialog(this);
    		}
    		
    		public void SetFtpClient()
    		{
    			TreeNode svrNode = new TreeNode("server", 0, 0);
    			svrNode.Nodes.Add("SE", "seoul", 0, 0);
    			svrNode.Nodes.Add("DJ", "seoul1", 0, 0);
    			svrNode.Nodes.Add("BS", "seoul2", 0, 0);
    
    			TreeNode netNode = new TreeNode("network", 1, 1);
    			netNode.Nodes.Add("T1", "Cable", 1, 1);
    			netNode.Nodes.Add("56K", "Modem", 1, 1);
    			netNode.Nodes.Add("3G", "Wireless", 1, 1);
    			tv_ftp.Nodes.Add(svrNode);
    			tv_ftp.Nodes.Add(netNode);
    		}
    	}
    }
