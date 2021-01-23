    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	static class Test
    	{
    		class Foo
    		{
    			public int Length { get { return Text != null ? Text.Length : 0; } }
    			public string Text { get; set; }
    		}
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var dataSet = Enumerable.Range(1, 10000).Select(n => new Foo { Text = new string('A', n) }).ToList();
    			var form = new Form();
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    			dg.DataSource = dataSet;
    			Application.Run(form);
    		}
    	}
    }
