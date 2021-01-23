        foreach (System.Data.DataTable table in datset.Tables)
        {
            if(table.Rows.Count == 0)
            {
                <code to add a new row>
            }//at this point the rest of the operations should work on the table
            WebCommon.Controls.GridView view = new WebCommon.Controls.GridView();
            ReportContainerPanel.Controls.Add(view);
            view.AutoGenerateColumns = true;
            view.ShowHeaderWhenEmpty = true;
            view.ShowHeader = true;
            view.ID = table.TableName;
            view.Size = WebCommon.Enums.TableSize.Small;
            view.DataSource = table;
            view.DataBind();
            // Add the spacer
            Literal spacer = new Literal();
            spacer.Text = "<br/>";
            ReportContainerPanel.Controls.Add(spacer);
        }
