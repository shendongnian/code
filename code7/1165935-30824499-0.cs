    private void button4_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
    
        for (var rowIndex = 0; rowIndex < dataGridView1.Rows.Count; ++rowIndex)
        {
            var row = dataGridView1.Rows[rowIndex];
            for (var cellIndex = 0; cellIndex < row.Cells.Count; ++cellIndex)
                sb.Append(row.Cells[cellIndex].Value).Append('&');
            // Replace the last '&' with a '%'
            if (sb.Length != 0)
                sb.Length[sb.Length - 1] = '%';
        }
    
        textBox1.Text = sb.ToString();
    }
