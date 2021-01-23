	using System.Collections.Generic;
	using System.Windows;
	using System.Windows.Input;
	namespace WpfApplication1
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			List<Person> ps = new List<Person>();
			List<Category> cs = new List<Category>();
			List<Books> bs = new List<Books>();
			public MainWindow()
			{
				InitializeComponent();
				//Bind to ps
				ps.Add(new Person { Name = "A", Phone = "000" });
				lb.DataContext = ps;
				//Bind to cs
				cs.Add(new Category { CategoryName = "cat", Rank = 1 });
				lb.DataContext = cs;
				//Bind to bs
				bs.Add(new Books { Name = "my book", Auther = "xxx", Company = "ABC" });
				lb.DataContext = bs;
			}
			private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
			{
				Title = e.OriginalSource.ToString();
			}
		}
		public class Person
		{
			public string Name { get; set; }
			public string Phone { get; set; }
		}
		public class Books
		{
			public string Name { get; set; }
			public string Auther { get; set; }
			public string Company { get; set; }
		}
		public class Category
		{
			public string CategoryName { get; set; }
			public int Rank { get; set; }
		}
	}
