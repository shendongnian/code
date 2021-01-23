    using System;
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
    			var textBox1 = new TextBox { Parent = form, Left = 16, Top = 16 };
    			var textBox2 = new TextBox { Parent = form, Left = 16, Top = textBox1.Bottom + 16 };
    			var bs = new BindingSource { DataSource = typeof(MyClass) };
    			textBox1.DataBindings.Add("Text", bs, "Field1", true, DataSourceUpdateMode.OnValidation, "");
    			textBox2.DataBindings.Add("Text", bs, "Field2", true, DataSourceUpdateMode.OnValidation, "");
    			bs.DataSource = new MyClass { Field1 = 1, Field2 = 2 };
    			Application.Run(form);
    		}
    	}
    
    	public class MyClass
    	{
    		private int? field1;
    		public int? Field1 { get; set; }
    		public int? Field2 { get; set; }
    	}
    }
