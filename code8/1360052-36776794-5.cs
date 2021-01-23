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
    			var splitView = new SplitContainer { Dock = DockStyle.Fill, Parent = form };
    			var textEntry = new TextEntryControl { Dock = DockStyle.Fill, Parent = splitView.Panel1 };
    			var textConsumer = new TextConsumingControl { Dock = DockStyle.Fill, Parent = splitView.Panel2 };
    			textConsumer.DataBindings.Add("MyStringProperty", textEntry, "MyStringProperty", true, DataSourceUpdateMode.Never);
    			Application.Run(form);
    		}
    	}
    
    	class TextEntryControl : UserControl
    	{
    		TextBox textBox;
    		public TextEntryControl()
    		{
    			textBox = new TextBox { Parent = this, Left = 16, Top = 16 };
    			textBox.DataBindings.Add("Text", this, "MyStringProperty", true, DataSourceUpdateMode.OnPropertyChanged);
    		}
    
    		string myStringProperty;
    		public string MyStringProperty
    		{
    			get { return myStringProperty; }
    			set
    			{
    				if (myStringProperty == value) return;
    				myStringProperty = value;
    				var handler = MyStringPropertyChanged;
    				if (handler != null) handler(this, EventArgs.Empty);
    			}
    		}
    
    		public event EventHandler MyStringPropertyChanged;
    	}
    
    	class TextConsumingControl : UserControl
    	{
    		Button button;
    		public TextConsumingControl()
    		{
    			button = new Button { Parent = this, Left = 16, Top = 16, Text = "Click Me" };
    			button.Bind("Enabled", this, "MyStringProperty", value => !string.IsNullOrEmpty(value as string));
    		}
    
    		string myStringProperty;
    		public string MyStringProperty
    		{
    			get { return myStringProperty; }
    			set
    			{
    				if (myStringProperty == value) return;
    				myStringProperty = value;
    				var handler = MyStringPropertyChanged;
    				if (handler != null) handler(this, EventArgs.Empty);
    			}
    		}
    
    		public event EventHandler MyStringPropertyChanged;
    	}
    
    	public static class BindingUtils
    	{
    		public static void Bind(this Control target, string targetProperty, object source, string sourceProperty, Func<object, object> expression)
    		{
    			var binding = new Binding(targetProperty, source, sourceProperty, true, DataSourceUpdateMode.Never);
    			binding.Format += (sender, e) => e.Value = expression(e.Value);
    			target.DataBindings.Add(binding);
    		}
    	}
    }
