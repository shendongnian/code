    public async Task<List<Category>> GetDataAsync1()
    {
        var db = new MyDbContext();
        var data = await db.Category.ToListAsync();
        return data;
    }
    public async Task<DataTable> GetDataAsync2()
    {
        var dt = new DataTable();
        var cn = @"Your Connection String";
        var cmd = @"SELECT * FROM Category";
        var da = new SqlDataAdapter(cmd, cn);
        await Task.Run(() => { da.Fill(dt); });
        return dt;
    }
    private async void Form1_Load(object sender, EventArgs e)
    {
        var data = await GetDataAsync1(); // await GetDataAsync2();
        this.dataGridView1.DataSource = data;
    }
