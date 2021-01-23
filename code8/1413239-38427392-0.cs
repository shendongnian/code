    public Task<List<Category>> GetDataAsync()
    {
        var db = new MyDbContext();
        //SQL Query is used just for example
        var q = db.Database.SqlQuery<Category>("SELECT * FROM Categories");
        var data = q.ToListAsync();
        return data;
    }
    private async void Form1_Load(object sender, EventArgs e)
    {
        var data = await GetDataAsync();
        this.dataGridView1.DataSource = data;
    }
