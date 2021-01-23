    private void BindGrid()
    {
        // Bind Grid
        var times = new List<Info>();
        times.Add(new Info(){ Time = "0:3:5" });
        times.Add(new Info() { Time = "0:2:10" });
        times.Add(new Info() { Time = "1:15:30" });
        this.dataGridView1.DataSource = times;
    
        // Retrieve total seconds
        double seconds = 0;
            seconds = dataGridView1.Rows.Cast<DataGridViewRow>()
                .AsEnumerable()
                .Sum(x => TimeSpan.Parse((x.Cells["Time"].Value.ToString())).TotalSeconds);
    
        // Assign to textbox
        textBox8.Text = TimeSpan.FromSeconds(seconds).Hours + ":" + TimeSpan.FromSeconds(seconds).Minutes
                + TimeSpan.FromSeconds(seconds).Seconds;
    }
