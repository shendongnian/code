    public partial class SalesPerProductPage : ContentPage
    {
        public SalesPerProductViewModel viewModelforSales { get; set; }
        public SalesPerProductPage()
        {
            InitializeComponent();
            viewModelforSales = new SalesPerProductViewModel();
            BindingContext = viewModelforSales;
        }
        async protected override void OnAppearing()
        {
            base.OnAppearing();
            var json = await GetSalesPerProductAsync();
            var salesPerProduct = JsonConvert.DeserializeObject<Sales[]>(json);
            PlotModel modelForSales = new PlotModel
            {
                Title = "Sales Per Product",
                TitleColor = OxyColors.Teal,
                TitleFontSize = 30,
                TextColor = OxyColors.White,
                DefaultFont = "Arial Black",
                DefaultFontSize = 20
            };
            dynamic seriesP2 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0, FontSize = 24 };
            foreach (Sales c in salesPerProduct)
            {
                seriesP2.Slices.Add(new PieSlice(c.PRODUCT_CODE, c.PRODUCT_ID));
            }
            modelForSales.Series.Add(seriesP2);
            viewModelforSales.SalesPerProductModel = modelForSales;
        }
        async Task<string> GetSalesPerProductAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.0.17:64550/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Sales");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else return response.ReasonPhrase;
        }
    }
