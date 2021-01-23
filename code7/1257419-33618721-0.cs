    foreach (DataGridViewRow row in dgvDonnees.Rows)
    {
        if (Convert.ToInt32(row.Cells[10].Value) == 0) continue;
        var cells = row.Cells.Cast<DataGridViewCell>();
        sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
    }
