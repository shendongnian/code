    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	public class Hierarchymain
    	{
    		public string Label;
    		public int ParentID;
    		public int ID;
    	}
    	static class Test
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var treeView = new TreeView { Dock = DockStyle.Fill, Parent = form };
    			Populate(treeView, new List<Hierarchymain> {
    				new Hierarchymain{ Label="THREE", ParentID=1, ID=2},
    				new Hierarchymain{ Label="six", ParentID=4, ID=5},
    				new Hierarchymain{ Label="Four", ParentID=2, ID=3},
    				new Hierarchymain{ Label="five", ParentID=3, ID=4},
    				new Hierarchymain{ Label="TWO", ParentID=0, ID=1},
    				new Hierarchymain{ Label="seven", ParentID=0, ID=6},
                    new Hierarchymain{ Label="ONE", ParentID=0, ID=0},
    			});
    			treeView.ExpandAll();
    			Application.Run(form);
    		}
    		static void Populate(TreeView treeView, List<Hierarchymain> source)
    		{
    			var itemById = source.ToDictionary(item => item.ID);
    			var nodeById = new Dictionary<int, TreeNode>();
    			var addStack = new Stack<Hierarchymain>();
    			foreach (var nextItem in source)
    			{
    				// Collect the info about the node that needs to be created and where
    				TreeNodeCollection parentNodes;
    				for (var item = nextItem; ; item = itemById[item.ParentID])
    				{
    					TreeNode node;
    					if (nodeById.TryGetValue(item.ID, out node))
    					{
    						// Already processed
    						parentNodes = node.Nodes;
    						break;
    					}
    					addStack.Push(item);
    					if (item.ParentID == item.ID)
    					{
    						// Root item
    						parentNodes = treeView.Nodes;
    						break;
    					}
    				}
    				// Create node for each collected item in reverse order
    				while (addStack.Count > 0)
    				{
    					var item = addStack.Pop();
    					var node = parentNodes.Add(item.Label);
    					nodeById.Add(item.ID, node);
    					parentNodes = node.Nodes;
    				}
    			}
    		}
    	}
    }
