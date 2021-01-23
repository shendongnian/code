            Int32 pickedValue = Int32.Parse(ddlOptions.SelectedValue);
                Table table = new Table();
              
                for (int i = 1; i <= pickedValue; i++)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Attributes.Add("runat", "server");
                    TextBox txt_splzn = new TextBox();
                    txt_splzn.ID = "txtB" + i.ToString();
                    txt_splzn.Text = "Text Number " + i.ToString();
                    cell.Controls.Add(txt_splzn);
                    row.Cells.Add(cell);
                    table.Rows.Add(row);
                    ctrlPlaceholder.Controls.Add(table);
                }
            }
        
    }
