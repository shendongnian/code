	public partial class MainWindow : Window
	{
		private List<curoLists> cLists;
		public MainWindow()
		{
			InitializeComponent();
		}
		// decorate this method with asyn
		private async void Window_Loaded(
			object sender, RoutedEventArgs e)
		{
			await PopulatelistAsync();
		}
		public async Task PopulatelistAsync()
		{
			try
			{
				curoListsDal _db = new curoListsDal();
				cLists = await _db.GetListsAync();
				listView.ItemsSource = cLists;
			}
			catch (Exception ex)
			{
			}
		}
	}
	public class curoListsDal
	{
		public async Task<List<curoLists>> GetListsAync()
		{
			return await
				Task.Run<List<curoLists>>(
					() =>
					{
						Thread.Sleep(2000); // long run
						var result = new List<curoLists>();
						for (var i = 0; i < 3; i++)
						{
							var id = Guid.NewGuid().ToString();
							var mlist = new curoLists(id,
								"title" + id, "subtitle", "imagePath",
								"desc", "content", true, 1);
							result.Add(mlist);
						}
						return result;
					});
		}
	}
