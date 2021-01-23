    //#define fBoundMode
    
    using System;
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
    			dg.DataSource = new BindingList<Data>();
    #else
    			dg.Columns.Add("Foo", "Foo");
    			dg.Columns.Add("Bar", "Bar");
    #endif
    			var status = new Label { Dock = DockStyle.Bottom, AutoSize = false, Parent = form };
    			var timer = new Timer { Interval = 250, Enabled = true };
    			timer.Tick += (sender, e) =>
    			{
    				var rowCount = dg.Rows.GetRowCount(DataGridViewElementStates.Visible) - (dg.NewRowIndex >= 0 ? 1 : 0);
                    status.Text = "Rows: " + rowCount;
    			};
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
