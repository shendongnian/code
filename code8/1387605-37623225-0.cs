    public partial class ContactInfo : ContentPage
    {
        private County item;
        public static async Task<string> GetContactString(string contactid)
        {
            HttpClient client = new HttpClient();
            var url = $"http://sema.dps.mo.gov/county/service.php?id={contactid}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responsetext = await response.Content.ReadAsStringAsync();
                return responsetext;
            }
            throw new Exception(response.ReasonPhrase);
        }
        public ContactInfo()
        {
            InitializeComponent();
            ContactInfoList = new ObservableCollection<ContactInfoModel>();
        }
        ObservableCollection<ContactInfoModel> ContactInfoList;
        public ContactInfo(County item) : this()
        {
            this.item = item;
            this.BindingContext = ContactInfoList;
        }
        protected override async void OnAppearing ()
        {
            if (item == null)
                return;
            var contact = await GetContactString(item.id);
            var models = JsonConvert.DeserializeObject<List<ContactInfoModel>>(contact);
            foreach (var model in models)
                ContactInfoList.Add(model);
        }
    }
