    private void button4_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
    
        foreach (DataRow row in dataGridView1.Rows)
        {
            foreach (DataCell cell in row.Cells)
                sb.Append(cell.Value).Append('&');
            // Replace the last '&' with a '%'
            if (sb.Length != 0)
                sb.Length[sb.Length - 1] = '%';
        }
    
        textBox1.Text = sb.ToString();
    }
