    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        /* Place indexes here, there is no need to initialize   *
         * so many integers inside loop if they're not changing */
        int indexOfYourColumn = 9, index2 = 0;
        var restaurantList = new List<Restaurant>();
        foreach (DataGridViewCell cell in dataGridView2.SelectedCells)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (cell.Value.ToString() == row.Cells[indexOfYourColumn].Value.ToString())
                {
                    restaurantList.Add(new Restaurant()
                    {
                        Data  = row.Cells[indexOfYourColumn].Value.ToString(),
                        Data2 = row.Cells[index2].Value.ToString()
                    });
                }
            }
        }
        dataGridView3.DataSource = restaurantList;
    }
