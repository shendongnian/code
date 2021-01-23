    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
    {
        if (dataGridView1.Rows[i].Cells[f.cmbColumnCombo.Text].Value.ToString()
                        .ToLower()
                        .Contains(f.txtfind.Text.ToLower()))
        {
            string input = dataGridView1.Rows[i].Cells[f.cmbColumnCombo.Text].Value.ToString();
            string pattern = f.txtfind.Text.ToLower();
            string replacement = f.txtreplace.Text;
            string output = Regex.Replace(input, pattern, replacement, RegexOptions.IgnoreCase);
            dataGridView1.Rows[i].Cells[f.cmbColumnCombo.Text].Value = output
                    bulidDataRow(i);
        }
    }
