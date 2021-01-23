    public async Task<DataTable> GetDataAsync(string command, string connection)
    {
        var dt = new DataTable();
        using (var da = new SqlDataAdapter(command, connection))
            await Task.Run(() => { da.Fill(dt); });
        return dt;
    }
    private async void LoadDataButton_Click(object sender, EventArgs e)
    {
        loadingPictureBox.Show();
        loadingPictureBox.Update();
        try
        {
            var command = @"SELECT * FROM Category";
            var connection = @"Your Connection String";
            var data = await GetDataAsync(command, connection);
            dataGridView1.DataSource = data;
        }
        catch (Exception ex)
        {
            //Handle Exception
        }
        loadingPictureBox.hide();
    }
