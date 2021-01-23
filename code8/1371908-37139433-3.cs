    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    
    			var form = new Form();
    			var splitView = new SplitContainer { Dock = DockStyle.Fill, Parent = form, Orientation = Orientation.Vertical };
    			var listView1 = new ListView { Dock = DockStyle.Fill, Parent = splitView.Panel1, View = View.List };
    			var listView2 = new ListView { Dock = DockStyle.Fill, Parent = splitView.Panel2, View = View.List };
    			var buttonPanel = new Panel { Dock = DockStyle.Bottom, Parent = form };
    			var button1 = new Button { Parent = buttonPanel, Left = 16, Top = 8, Text = ">" };
    			var button2 = new Button { Parent = buttonPanel, Left = button1.Right + 16, Top = 8, Text = "<" };
    			buttonPanel.Height = button1.Height + 16;
    
    			var dictList = new Dictionary<string, int>
    			{
    				{ "first", 0 },
    				{ "second", 1 },
    				{ "third", 2 },
    				{ "fourth", 3 },
    				{ "fifth", 4 },
    				{ "sixth", 5 },
    				{ "seventh", 6 },
    			};
    			foreach (var item in dictList)
    				listView1.Items.Insert(item.Value, item.Key);
    
    			Action<ListView, ListView, int> MoveSelectedItems = (ListView source, ListView target, int flag) =>
    			{
    				while (source.SelectedItems.Count > 0)
    				{
    					var item = source.SelectedItems[0];
    					source.Items.Remove(item);
    					if (flag == 0)
    					{
    						target.Items.Add(item);
    					}
    					else
    					{
    						int index = dictList[item.Text];
    						// Insert at appropriate position based on index value
    						if (index == 0) // Always first
    							target.Items.Insert(0, item);
    						else if (index == dictList.Count - 1) // Always last
    							target.Items.Add(item);
    						else
    						{
    							// Binary search the current target items
    							int lo = 0, hi = target.Items.Count - 1;
    							while (lo <= hi)
    							{
    								int mid = lo + (hi - lo) / 2;
    								if (index < dictList[target.Items[mid].Text])
    									hi = mid - 1;
    								else
    									lo = mid + 1;
    							}
    							// Here lo variable contains the insert position
    							target.Items.Insert(lo, item);
    						}
    					}
    				}
    			};
    
    			button1.Click += (sender, e) => MoveSelectedItems(listView1, listView2, 0);
    			button2.Click += (sender, e) => MoveSelectedItems(listView2, listView1, 1);
    
    			Application.Run(form);
    		}
    	}
    }
