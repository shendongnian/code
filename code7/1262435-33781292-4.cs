        private void InitializeGrid()
        {
            try
            {
                ViewState["applicationDetail"] = null;
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[]
                { 
                new DataColumn("Id", typeof(int)),
                new DataColumn("FirstEntry", typeof(string)),
                new DataColumn("SecondEntry",typeof(string)),
                new DataColumn("FirstTextBox", typeof(string)),
                new DataColumn("SecondTextBox", typeof(string))
                                
                });
                DataRow drRow = dt.NewRow();
                drRow["Id"] = 1;
                drRow["FirstEntry"] = string.Empty;
                drRow["SecondEntry"] = string.Empty;
                drRow["FirstTextBox"] = string.Empty;
                drRow["SecondTextBox"] = string.Empty;
                dt.Rows.Add(drRow);
                ViewState["applicationDetail"] = dt;
                GridView1.DataSource = ViewState["applicationDetail"];
            }
            catch (Exception ex)
            {
                throw;
            }
        }
