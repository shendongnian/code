    private void ComboBoxCompaniesSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Client client = e.AddedItems[0] as Client;
        if (client != null)
        {
            TruckServiceClient tsc = null; // ...
            List<Representative> representatives = GetRepByComp(tsc, client.Id.ToString());
            comboBoxRepresentatives.ItemsSource = representatives;
        }
    }
