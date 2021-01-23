    public class DataGridExtensions
    {
    	public static readonly DependencyProperty ObserveVisiblePersonsProperty = DependencyProperty.RegisterAttached(
    		"ObserveVisiblePersons", typeof(bool), typeof(DataGridExtensions),
    		new PropertyMetadata(false, OnObserveVisiblePersonsChanged));
    
    	public static readonly DependencyProperty VisiblePersonsProperty = DependencyProperty.RegisterAttached(
    		"VisiblePersons", typeof(List<Person>), typeof(DataGridExtensions),
    		new PropertyMetadata(null));
    
    	private static readonly DependencyProperty SenderDataGridProperty = DependencyProperty.RegisterAttached(
    		"SenderDataGrid", typeof(DataGrid), typeof(DataGridExtensions), new PropertyMetadata(default(DataGrid)));
    
    	private static void OnObserveVisiblePersonsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		DataGrid dataGrid = d as DataGrid;
    		if (dataGrid == null)
    			return;
    		dataGrid.Loaded += DataGridLoaded;
    	}
    
    	private static void DataGridLoaded(object sender, RoutedEventArgs routedEventArgs)
    	{
    		DataGrid dataGrid = (DataGrid) sender;
    		dataGrid.Loaded -= DataGridLoaded;
    		ScrollViewer scrollViewer = FindChildren<ScrollViewer>(dataGrid).FirstOrDefault();
    		if (scrollViewer != null)
    		{
    			SetSenderDataGrid(scrollViewer, dataGrid);
    			scrollViewer.ScrollChanged += ScrollViewerOnScrollChanged;
    		}
    	}
    
    	public static void SetObserveVisiblePersons(DependencyObject element, bool value)
    	{
    		element.SetValue(ObserveVisiblePersonsProperty, value);
    	}
    
    	public static bool GetObserveVisiblePersons(DependencyObject element)
    	{
    		return (bool) element.GetValue(ObserveVisiblePersonsProperty);
    	}
    
    	private static void SetSenderDataGrid(DependencyObject element, DataGrid value)
    	{
    		element.SetValue(SenderDataGridProperty, value);
    	}
    
    	private static DataGrid GetSenderDataGrid(DependencyObject element)
    	{
    		return (DataGrid) element.GetValue(SenderDataGridProperty);
    	}
    
    	private static void ScrollViewerOnScrollChanged(object sender, ScrollChangedEventArgs e)
    	{
    		ScrollViewer scrollViewer = sender as ScrollViewer;
    		if (scrollViewer == null)
    			return;
    
    		ScrollBar verticalScrollBar =
    			FindChildren<ScrollBar>(scrollViewer).FirstOrDefault(s => s.Orientation == Orientation.Vertical);
    		if (verticalScrollBar != null)
    		{
    			DataGrid dataGrid = GetSenderDataGrid(scrollViewer);
    
    			int totalCount = dataGrid.Items.Count;
    			int firstVisible = (int) verticalScrollBar.Value;
    			int lastVisible = (int) (firstVisible + totalCount - verticalScrollBar.Maximum);
    
    			List<Person> visiblePersons = new List<Person>();
    			for (int i = firstVisible; i <= lastVisible; i++)
    			{
    				visiblePersons.Add((Person) dataGrid.Items[i]);
    			}
    			SetVisiblePersons(dataGrid, visiblePersons);
    		}
    	}
    
    	public static void SetVisiblePersons(DependencyObject element, List<Person> value)
    	{
    		element.SetValue(VisiblePersonsProperty, value);
    	}
    
    	public static List<Person> GetVisiblePersons(DependencyObject element)
    	{
    		return (List<Person>) element.GetValue(VisiblePersonsProperty);
    	}
    
    	private static IList<T> FindChildren<T>(DependencyObject element) where T : FrameworkElement
    	{
    		List<T> retval = new List<T>();
    		for (int counter = 0; counter < VisualTreeHelper.GetChildrenCount(element); counter++)
    		{
    			FrameworkElement toadd = VisualTreeHelper.GetChild(element, counter) as FrameworkElement;
    			if (toadd != null)
    			{
    				T correctlyTyped = toadd as T;
    				if (correctlyTyped != null)
    				{
    					retval.Add(correctlyTyped);
    				}
    				else
    				{
    					retval.AddRange(FindChildren<T>(toadd));
    				}
    			}
    		}
    		return retval;
    	}
    }
