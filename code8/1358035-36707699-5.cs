    for (int i = 0; i < gv.Rows.Count; i++)
    {
        html += "<tr>";
        for (int j = 0; j < gv.Columns.Count; j++)
        {
            TableCell cell = gv.Rows[i].Cells[j];
            html += "<td>";
            if (cell.Controls.Count > 1 && cell.Controls[1] is Label)
            {
                Label lblValue = cell.Controls[1] as Label;
                html += lblValue.Text;
            }
            else
            {
                html += cell.Text;
            }
            html += "</td>";
        }
        html += "</tr>";
    }
