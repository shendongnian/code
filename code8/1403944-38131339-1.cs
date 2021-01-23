    public async void Button1_Click(object sender, EventArgs args)
    {
        await LoadData();
    }
    
    private async Task LoadData()
    {
        List<Bar> bars = await myConnectionClass.RequestDataAsync();
        SomeBinding.DataSource = bars;
    }
