    using System;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class Test
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var treeView = new TreeView { Dock = DockStyle.Fill, Parent = form };
    			for (int i = 1; i <= 10; i++)
    			{
    				var parent = new TreeNode { Text = "Parent#" + i };
    				treeView.Nodes.Add(parent);
    				for (int j = 1; j <= 10; j++)
    				{
    					var child = new TreeNode { Text = "Child#" + i };
    					var dummy = new TreeNode();
    					child.Nodes.Add(dummy);
    					parent.Nodes.Add(child);
    				}
    			}
    
    			var random = new Random();
    			int addCount = 0;
    			treeView.NodeMouseClick += (sender, e) =>
    			{
    				if (treeView.SelectedNode == e.Node && e.Node.IsExpanded)
    				{
    					treeView.BeginUpdate();
    					e.Node.Nodes.Clear();
    					int count = random.Next(20) + 1;
    					for (int i = 1; i <= count; i++)
    					{
    						var child = new TreeNode { Text = "AddChild#" + (++addCount) };
    						var dummy = new TreeNode();
    						child.Nodes.Add(dummy);
    						e.Node.Nodes.Add(child);
    					}
    					treeView.EndUpdate();
    				}
    			};
    
    			Application.Run(form);
    		}
    	}
    }
