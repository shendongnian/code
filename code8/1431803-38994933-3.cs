    namespace CollectionBindingDemo
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    		}
    
    		private void Add_Click(object sender, RoutedEventArgs e)
    		{
    			CollectionList.Add();
    		}
    
    		private void Remove_Click(object sender, RoutedEventArgs e)
    		{
    			var i = ListVeiw.SelectedItem as int?;
    			if(i.HasValue)
    				CollectionList.Remove(i.Value);
    		}
    	}
    }
