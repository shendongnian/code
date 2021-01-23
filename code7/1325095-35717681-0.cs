    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        try
        {
            Task.Run(() => getData());
        }
        catch (Exception ex)
        {
            MessageBox.Show(""+ex);
        }
    }
    public async Task getData()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync("http://api.androidhive.info/contacts/");
            var data = await response.Content.ReadAsStringAsync();
            PersonList contactdata = JsonConvert.DeserializeObject<PersonList>(data.Result.ToString());
            listcontact.ItemsSource = contactdata.contacts;
        }
    }
