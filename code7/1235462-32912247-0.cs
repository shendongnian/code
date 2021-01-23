    using System;
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
    			var categories = Enumerable.Range(1, 10).Select(n => new Category { Name = "Category" + n }).ToList();
    			var products = Enumerable.Range(1, 50).Select(n => new Product { Name = "Product" + n, Category = categories[(n - 1) % categories.Count] }).ToList();
    			var form = new Form();
    			var dg = new DataGridView { Dock = DockStyle.Fill, Parent = form, AutoGenerateColumns = false };
    			dg.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name" });
    			var categoryColumn = new DataGridViewComboBoxColumn { DisplayStyleForCurrentCellOnly = true };
    			// data part
    			categoryColumn.DataPropertyName = "Category"; // bind to Product.Category property
    			// list part
    			categoryColumn.DisplayMember = "Name"; // bind to Category.Name property
    			categoryColumn.ValueMember = "Self"; // w/o this it doesn't work
    			categoryColumn.DataSource = categories;
    			dg.Columns.Add(categoryColumn);
    			dg.DataSource = products;
    			Application.Run(form);
    		}
    	}
    	public class Category
    	{
    		public string Name { get; set; }
    		public Category Self { get { return this; } } 
    	}
    	public class Product
    	{
    		public string Name { get; set; }
    		public Category Category { get; set; }
    	}
    }
