    public partial class ClientListPage : ContentPage
    {
        CustomerVM viewModel;
        public ClientListPage()
        {
            InitializeComponent();
            viewModel = new CustomerVM();
            BindingContext = viewModel;
        }
        async override protected void OnAppearing()
        {
            base.OnAppearing();
            var json = await GetCustomersAsync();
            var customers = JsonConvert.DeserializeObject<CustomerViewModel[]>(json);
            foreach (CustomerViewModel c in customers)
                viewModel.CustomerList.Add(c);
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
