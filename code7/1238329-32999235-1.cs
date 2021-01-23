    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Tests
    {
    	enum MyEnum {  Red, Green, }
    	class Controller
    	{
    		public MyEnum SelectedValue { get; set; }
    	}
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
    			combo.DataSource = (MyEnum[])Enum.GetValues(typeof(MyEnum));
    			var c = new Controller();
    			combo.DataBindings.Add(new Binding("SelectedValue", c, "SelectedValue", true, DataSourceUpdateMode.OnPropertyChanged));
    			form.BindingContextChanged += (sender, e) =>
    			{
    				// If you change combo binding formatting enabled parameter to false,
    				// the next will throw the exception you are getting
    				c.SelectedValue = MyEnum.Red;
    			};
    			var panel1 = new Panel { Dock = DockStyle.Fill, Parent = form, BackColor = Color.Red };
    			var panel2 = new Panel { Dock = DockStyle.Fill, Parent = form, BackColor = Color.Green };
    			Bind(panel1, "Visible", combo, "SelectedValue", value => (MyEnum)value == MyEnum.Red);
    			Bind(panel2, "Visible", combo, "SelectedValue", value => (MyEnum)value == MyEnum.Green);
    			Application.Run(form);
    		}
    		static void Bind(Control target, string targetProperty, object source, string sourceProperty, Func<object, object> expression)
    		{
    			var binding = new Binding(targetProperty, source, sourceProperty, false, DataSourceUpdateMode.Never);
    			binding.Format += (sender, e) => e.Value = expression(e.Value);
    			target.DataBindings.Add(binding);
    		}
    	}
    }
