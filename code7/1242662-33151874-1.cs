    using System;
    using System.Windows.Forms;
    namespace Tests
    {
    	class Person
    	{
    		public string FirstName { get; set; }
    		public string LastName { get; set; }
    	}
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    			var filterBox = new TextBox { Dock = DockStyle.Bottom, Parent = form };
    			var data = new MyBindingList<Person>(new[]
    			{
    				new Person { FirstName = "Jon", LastName = "Skeet" },
    				new Person { FirstName = "Hans", LastName = "Passant" },
    				new Person { FirstName = "Ivan", LastName = "Stoev" },
    			});
    			dg.DataSource = data;
    			var filterText = string.Empty;
    			filterBox.TextChanged += (sender, e) =>
    			{
    				var text = filterBox.Text.Trim();
    				if (filterText == text) return;
    				filterText = text;
    				if (!string.IsNullOrEmpty(filterText))
    					data.Filter = person => person.FirstName.Contains(filterText) || person.LastName.Contains(filterText);
    				else
    					data.Filter = null;
    			};
    			Application.Run(form);
    		}
    	}
    }
