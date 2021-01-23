    //#define fBoundMode
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    #if fBoundMode
    			dg.DataSource = new BindingList<Data>(new List<Data> { new Data { Foo = "a" }, new Data { Foo = "b" } }) { AllowNew = false };
    #else
    			dg.Columns.Add("Foo", "Foo");
    			dg.Columns.Add("Bar", "Bar");
    			dg.Rows.Add("a", "a");
    			dg.Rows.Add("b", "b");
    			dg.Rows.Add("c", "c");
    			dg.Rows[1].Visible = false;
    #endif
    			var status = new Label { Dock = DockStyle.Bottom, AutoSize = false, Parent = form };
    			Action updateStatus = () =>
    			{
    				var rowCount = dg.Rows.Count - (dg.AllowUserToAddRows ? 1 : 0);
    				status.Text = "Rows: " + rowCount;
    			};
    			dg.UserDeletedRow += (sender, e) => updateStatus();
    			var timer = new Timer { Interval = 250, Enabled = true };
    			timer.Tick += (sender, e) => updateStatus();
    			Application.Run(form);
    		}
    #if fBoundMode
            class Data
            {
                public string Foo { get; set; }
                public string Bar { get; set; }
            }
    #endif
    	}
    }
