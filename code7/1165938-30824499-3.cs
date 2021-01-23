    private void button4_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
    
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
                sb.Append(cell.Value).Append('&');
            // Replace the last '&' with a '%'
            if (sb.Length != 0)
                sb[sb.Length - 1] = '%';
        }
    
        textBox1.Text = sb.ToString();
    }
