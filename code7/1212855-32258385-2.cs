	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			Collection = new ObservableCollection<Person>();
			InitializeComponent();
		}
		public class Person
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}
		public ObservableCollection<Person> Collection { get; set; }
		public List<Person> Persons { get; set; }
		private void WindowLoaded(object sender, RoutedEventArgs e)
		{
			this.Persons = new List<Person>();
			for (int i = 0; i != 35; i++)
			{
				this.Persons.Add(new Person() { Age = i, Name = i.ToString() });
			}
			foreach (var p in Persons)
			{
				Collection.Add(p);
			}
		}
	}
    
