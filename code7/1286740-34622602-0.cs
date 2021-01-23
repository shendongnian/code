	namespace WpfApplication1
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
			}
			private void button1_Click(object sender, RoutedEventArgs e)
			{
				// Add Columns to the dataGrid
				DataGridTextColumn c1 = new DataGridTextColumn();
				c1.Header = "Person ID";
				c1.Binding = new Binding("ID");
				c1.Width = 110;
				dataGrid1.Columns.Add(c1);
				DataGridTextColumn c2 = new DataGridTextColumn();
				c2.Header = "First Name";
				c2.Width = 110;
				c2.Binding = new Binding("FirstName");
				dataGrid1.Columns.Add(c2);
				DataGridTextColumn c3 = new DataGridTextColumn();
				c3.Header = "Last Name";
				c3.Width = 110;
				c3.Binding = new Binding("LastName");
				dataGrid1.Columns.Add(c3);
				// Create the Data
				List<Person> myData = new List<Person>();
				myData.Add(new Person() { ID = 5, FirstName = "Jamie", LastName = "White" });
				myData.Add(new Person() { ID = 10, FirstName = "Mike", LastName = "Smith" });
				myData.Add(new Person() { ID = 25, FirstName = "Joe", LastName = "Yang" });
				// Pass the data to the dataGrid
				dataGrid1.ItemsSource = myData;
				//// OR
				//dataGrid1.Items.Add(new Person() { ID = 5, FirstName = "Jamie", LastName = "Weir" });
				//dataGrid1.Items.Add(new Person() { ID = 10, FirstName = "Mike", LastName = "Smith" });
				//dataGrid1.Items.Add(new Person() { ID = 25, FirstName = "Joe", LastName = "Yang" });
				
				// Modify a cell
				((Person)dataGrid1.Items[1]).LastName = "Schmidt";
				
			}
		}
		public class Person
		{
			public int ID { set; get; }
			public string FirstName { set; get; }
			public string LastName { set; get; }
		}
		
	}
