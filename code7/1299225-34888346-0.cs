    namespace myNamespace
	{
		public partial class MainWindow : Window
		{
			public IDBContext context { get; set; }
			public MainWindow()
			{
				InitializeComponent();
				LoadTables()
			}
			
			private void LoadTables()
			{
				if(cbEnvironment.Text == "Production")
				{
					context = new Entities1(); 
				}
				else 
				{
					context = new Entities2();
				}
			}
			
		}
		public interface IDBContext
		{
			IDbSet<Table1> Table1 { get; set; }
			IDbSet<Table2> Table2 { get; set; }        
		}
		
	}
	
	namespace myNamespace
	{
		using System;
		using System.Data.Entity;
		using System.Data.Entity.Infrastructure;
		
		public partial class Entities1 : DbContext, IBassContext
		{
			public Entities1()
				: base("name=Entities1")
			{
			}
		
			protected override void OnModelCreating(DbModelBuilder modelBuilder)
			{
				throw new UnintentionalCodeFirstException();
			}
		
			public virtual IDbSet<Table1> Table1 { get; set; }
			public virtual IDbSet<Table2> Table1 { get; set; }
		}
	}
	
	namespace myNamespace
	{
		using System;
		using System.Data.Entity;
		using System.Data.Entity.Infrastructure;
		
		public partial class Entities2 : DbContext, IBassContext
		{
			public Entities2()
				: base("name=Entities2")
			{
			}
		
			protected override void OnModelCreating(DbModelBuilder modelBuilder)
			{
				throw new UnintentionalCodeFirstException();
			}
		
			public virtual IDbSet<Table1> Table1 { get; set; }
			public virtual IDbSet<Table2> Table1 { get; set; }
		}
	}
	
	
