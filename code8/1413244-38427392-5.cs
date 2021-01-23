    public async Task<DataTable> GetDataAsync(string command, string connection)
    {
        var dt = new DataTable();
        using (var da = new SqlDataAdapter(command, connection))
            await Task.Run(() => da.Fill(dt));
        return dt;
    }
    private async void Form1_Load(object sender, EventArgs e)
    {
        var command = @"SELECT * FROM Category";
        var connection = @"Your Connection String";
        var data = await GetDataAsync(command, connection);
        this.dataGridView1.DataSource = data;
    }
