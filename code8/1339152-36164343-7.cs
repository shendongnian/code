    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    		var data = new[]
    		{
    			new RegionSale { DateSale = new DateTime(2015, 12, 03), Region = "UK", DollarAmount = 23634 },
    			new RegionSale { DateSale = new DateTime(2015, 12, 03), Region = "US", DollarAmount = 22187 },
    			new RegionSale { DateSale = new DateTime(2015, 12, 04), Region = "UK", DollarAmount = 56000 },
    			new RegionSale { DateSale = new DateTime(2015, 12, 04), Region = "US", DollarAmount = 22187 },
    			new RegionSale { DateSale = new DateTime(2015, 12, 14), Region = "UK", DollarAmount = 56000 },
    			new RegionSale { DateSale = new DateTime(2015, 12, 14), Region = "US", DollarAmount = 10025 },
    		};
    		DataContext = new ViewModel { PivotView = new RegionSalePivotView(data) };
    	}
    }
