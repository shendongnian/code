    public partial class MainPage : ContentPage
    {
        CustomerViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new CustomerViewModel();
            BindingContext = viewModel;
        }
        async override protected void OnAppearing()
        {
            base.OnAppearing();
            var json = await GetCustomersAsync();
            var customers = JsonConvert.DeserializeObject<Customer[]>(json);
            foreach (Customer c in customers)
                viewModel.CustomerCollection.Add(c);
        }
        async Task<string> GetCustomersAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.0.17:55365/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = await client.GetAsync("api/Customers");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else return response.ReasonPhrase;
        }
    }
