    protected void Page_PreRender(object sender, EventArgs e)
        {
            string lastInsertedRowValue = string.Empty;
            // only highlight the row if last inserted values are NOT a Hyphen -
            if (ViewState["LastRowUniqueValue"] != "-")
            {
                // Assuming the Unique value is String, else cast accordingly
                string lastInsertedRowValue = (string)ViewState["LastRowUniqueValue"];
                
                int rowCnt = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                   string CellText = row.Cells[0].Text;
                    if (CellText.Equals(lastInsertedRowValue))
                    {
                        row.Attributes.Add(“bgcolor”, “Yellow”);
                        break;
                    }
                    rowCnt++;
                }
            }
        }
