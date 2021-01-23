    for (int i = 0; i < dgvNalog.RowCount; i++)
    {
        var row = dgvNalog.Rows[i];
        rowIsEmpty = true;
        if (Convert.ToDouble(row.Cells["Kolicina"].Value) == 0)
        {
            rowIsEmpty = false;
            dgvNalog.Rows[i].Cells["Kolicina"].Style.BackColor = Color.Red;
            // break; -> comment this to allow other rows to be processed
        }
    }
