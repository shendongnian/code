    for (int i = 0; i < GridView.Rows.Count; i++)
            {
                if(GridView.Rows[i].Cells[6].Text == "0" || GridView.Rows[i].Cells[6].Text == "NULL")
                {
                     GridView.Rows[i].Cells[6].Style.Add("background-color", "green");
                }
                else
                    GridView.Rows[i].Cells[6].Style.Add("background-color", "red");
                }
            }
