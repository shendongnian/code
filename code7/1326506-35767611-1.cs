            protected void transactionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            GridViewRow row;
            int batchID;
            processPayBatch dal = new processPayBatch();
            switch (e.CommandName)
            {
                case "exportBatch":
                    index = Convert.ToInt32(e.CommandArgument);
                    row = transactionGrid.Rows[index];
                    batchID = Convert.ToInt32(row.Cells[1].Text);
                    Session["csvbatch"] = batchID;
                    csvFrame.Attributes["src"] = "/CSVExport/ExportToCsv.aspx";
                    
                    //Download the CSV file.
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.frames[0].document.forms[0].submit();", true);
                    break;
              
            }
        }
