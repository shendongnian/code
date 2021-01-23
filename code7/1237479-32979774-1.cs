    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Tests
    {
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var topPanel = new Panel { Dock = DockStyle.Top, Parent = form };
    			var combo = new ComboBox { Left = 8, Top = 8, Parent = topPanel };
    			topPanel.Height = combo.Height + 16;
    			combo.Items.AddRange(new[] { "One", "Two" });
    			combo.SelectedIndex = 0;
    			var panel1 = new Panel { Dock = DockStyle.Fill, Parent = form, BackColor = Color.Red };
    			var panel2 = new Panel { Dock = DockStyle.Fill, Parent = form, BackColor = Color.Green };
    			Bind(panel1, "Visible", combo, "SelectedIndex", value => (int)value == 0);
    			Bind(panel2, "Visible", combo, "SelectedIndex", value => (int)value == 1);
    			Application.Run(form);
    		}
    		static void Bind(Control target, string targetProperty, object source, string sourceProperty, Func<object, object> expression)
    		{
    			var binding = new Binding(targetProperty, source, sourceProperty, true, DataSourceUpdateMode.Never);
    			binding.Format += (sender, e) => e.Value = expression(e.Value);
    			target.DataBindings.Add(binding);
    		}
    	}
    }
