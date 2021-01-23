     public void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(LoadSomeData));
    }
    public async Task LoadSomeData()
    {
        var clientcontacts = Client.DownloadStringTaskAsync("api/contacts");
        var clienttemperature =     Client.DownloadStringTaskAsync("api/temperature");
        var clientlocation = Client.DownloadStringTaskAsync("api/location");
        await Task.WhenAll(clientcontacts, clienttemperature, clientlocation);
        var contacts =     Newtonsoft.Json.JsonConvert.DeserializeObject<List<Contact>>(await clientcontacts);
        var location = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await clientlocation);
        var temperature = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await clienttemperature);
 
        listcontacts.DataSource = contacts;
        listcontacts.DataBind();
        Temparature.Text = temperature;
        Location.Text = location;
    }
