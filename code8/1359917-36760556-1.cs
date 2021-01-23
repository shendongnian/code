    public partial class TestListView : ContentPage
	{
		public TestListView ()
		{
			InitializeComponent ();
			ObservableCollection<DataItem> employeeList = new ObservableCollection<DataItem>();
			for(int i=0;i<100;i++)
				employeeList.Add(new DataItem(i));
			uiList.ItemsSource = employeeList;
			//Mr. Mono will be added to the ListView because it uses an ObservableCollection
		}
	}
	public class DataItem
	{
		public int Number { get; set; }
		public string Message { get; set; }
		public DataItem (int i)
		{
			this.Number = i + 1;
			this.Message = string.Format ("Data Item Hello {0}", i + 1);
		}
	}
