    public class MainPage : ContentPage
    {
        public MainPage (bool chart)
        {           
            ChartView chartView = new ChartView 
            { 
                VerticalOptions = LayoutOptions.FillAndExpand, 
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 300,
                WidthRequest = 400
            };    
        }
    
        public static async Task<MainPage> CreateMainPageAsync(bool chart)
        {
             MainPage page = new MainPage();
             
            LineModel test1 = new LineModel();
            chartView.Model = await test1.GetModelAsync(); 
            page.Content = whatever;
            
            return page;
        }
    }
