    public async Task<DataTable> GetDataAsync()
    {
        var dt = new DataTable();
        var cn = @"Your Connection String";
        var cmd = @"SELECT * FROM Category";
        var da = new SqlDataAdapter(cmd, cn);
        await Task.Run(() => { da.Fill(dt); });
        return dt;
    }
    private async void LoadDataButton_Click(object sender, EventArgs e)
    {
        loadingPictureBox.Show();
        loadingPictureBox.Update();
        try
        {
            var data = await GetDataAsync();
            dataGridView1.DataSource = data;
        }
        catch (Exception ex)
        {
            //Handle Exception
        }
        loadingPictureBox.hide();
    }
