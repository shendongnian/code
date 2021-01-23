    public async Task<DataTable> GetData()
    {
        //Your load logic
    }
    private async void Form_Load(object sender, EventArgs e)
    {
        this.ComboBox.DataSource = await GetData();
    }
