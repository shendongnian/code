    int iteration=0;
    
    private void button7_Click(object sender, EventArgs e)
        {           
            for (int i = iteration; i < gridView1.RowCount; i++)
            {
                var row = gridView1.GetDataRow(i);
                var genre = row["genre"].ToString();
    
                if (genre.IndexOf(textBox8.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    gridView1.FocusedRowHandle = i;
                    iteration=i+1;                
                    break;
                }
            }
        }   
