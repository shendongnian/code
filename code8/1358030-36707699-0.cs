    for (int i = 0; i < gv.Rows.Count; i++)
    {
        for (int j = 0; j < gv.Columns.Count; j++)
        {
            html += "<td>";
            if (gv.Rows[i].Cells[j].Controls.Count > 1)
            {
                Label lblValue = gvPersons.Rows[i].Cells[j].Controls[1] as Label;
                html += lblValue.Text;
            }
            else
            {
                html += gv.Rows[i].Cells[j].Text.ToString();
            }
            html += "</td>";
        }
    }
