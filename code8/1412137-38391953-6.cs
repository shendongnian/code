    public partial class SalesPage : ContentPage
    {
        Label resultsLabel;
        SearchBar searchBar;
        public SalesPage()
        {
            resultsLabel = new Label {   //...  };
            searchBar = new SearchBar {   //...  };
    	    var searchLabel = new Label() 
    	    {
            	HorizontalTextAlignment = TextAlignment.Center,
            	Text = "SearchBar",
            	FontSize = 50,
            	TextColor = Color.Purple
            };
    	    MainLayout.Add(searchLabel);
    	    Mainlayout.Add(searchBar);
    	    MainLayout.Add(resultLabel);
    	    MainLayout.Add(searchLabel);
            var scrollView = new ScrollView()
            {
            	Content = resultsLabel,
             	VerticalOptions = LayoutOptions.FillAndExpand
            };
    	    MainLayout.Add(scrollView);
    	    MainLayout.VerticalOptions = LayoutOptions.Start;
    	    MainLayout.Padding =  new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5); 
        }
    }
