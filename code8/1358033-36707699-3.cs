    for (int i = 0; i < gv.Rows.Count; i++)
    {
        for (int j = 0; j < gv.Columns.Count; j++)
        {
            html += "<td>";
            if (gv.Rows[i].Cells[j].Controls.Count > 1 && gv.Rows[i].Cells[j].Controls[1] is Label)
            {
                Label lblValue = gv.Rows[i].Cells[j].Controls[1] as Label;
                html += lblValue.Text;
            }
            else
            {
                html += gv.Rows[i].Cells[j].Text;
            }
            html += "</td>";
        }
    }
