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
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form };
    			dg.CellFormatting += (sender, e) =>
    			{
    				var dog = e.Value as Dog;
    				if (dog != null) { e.Value = dog.Name; e.FormattingApplied = true; }
    			};
    			dg.DataSource = new[]
    			{
    				new Person { First_Name = "Ben", Last_Name = "Harison", dog = new Dog { Name = "Billy", Age = 50} },
    				new Person { First_Name = "Rob", Last_Name = "Jonson", dog = new Dog { Name = "Puppy", Age = 25} },
    			};
    			Application.Run(form);
    		}
    	}
    
    	public class Dog
    	{
    		public String Name { get; set; }
    		public int Age { get; set; }
    	}
    	public class Person
    	{
    		public String First_Name { get; set; }
    		public String Last_Name { get; set; }
    		public Dog dog { get; set; }
    	}
    }
