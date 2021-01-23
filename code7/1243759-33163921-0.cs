    using System;
    using System.Data;
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
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    			var data = GetData();
    			dg.DataSource = data;
    			var updateTimer = new Timer { Interval = 200, Enabled = true };
    			updateTimer.Tick += (sender, e) =>
    			{
    				foreach (var dr in GetData().AsEnumerable())
    					data.LoadDataRow(dr.ItemArray, LoadOption.OverwriteChanges);
    			};
    			Application.Run(form);
    		}
    		static DataTable GetData()
    		{
    			var dt = new DataTable();
    			dt.Columns.Add("Id", typeof(int));
    			dt.Columns.Add("Name");
    			dt.Columns.Add("Score", typeof(int));
    			dt.PrimaryKey = new[] { dt.Columns["Id"] };
    			var random = new Random();
    			for (int i = 1; i <= 1000; i++)
    				dt.Rows.Add(i, "Player #" + i, random.Next(1, 100000));
    			return dt;
    		}
    	}
    }
