    var cell = dataGridView1.Rows[i].Cells[f.cmbColumnCombo.Text];
    var oldValue = cell.Value.ToString();
    cell.Value = Regex.Replace(cell.Value.ToString(), f.cmbColumnCombo.Text, f.txtreplace.Text, RegexOptions.IgnoreCase);
    if ((string)cell.Value != oldValue)
         bulidDataRow(i);
        
