            GridViewRow gvrow1 = GrdDynamic1.HeaderRow;
            foreach (GridViewRow row in GrdDynamic1.Rows)
            {
                for (int i = 0; i < GrdDynamic1.Columns.Count; i++)
                {
                    String header = GrdDynamic1.Columns[i].HeaderText;
                    DropDownList cellText = ((DropDownList)gvrow1.Cells[i].FindControl("FieldValues"));
                }
            }
