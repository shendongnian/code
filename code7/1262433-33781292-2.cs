        protected void btnNewRow_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewRowToGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AddNewRowToGrid()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["applicationDetail"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["applicationDetail"];
                    DataRow drCurrentRow = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values  _lblGuestId
                            DropDownList ddl1 = GridView1.Rows[rowIndex].FindControl("ddlFirstEntry") as DropDownList;
                            DropDownList ddl2 = GridView1.Rows[rowIndex].FindControl("ddlSecondEntry") as DropDownList;
                            TextBox txt1 = GridView1.Rows[rowIndex].FindControl("txtFirstTextBox") as TextBox;
                            TextBox txt2 = GridView1.Rows[rowIndex].FindControl("txtSecondTextBox") as TextBox;
                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["RowNumber"] = i + 1;
                            dtCurrentTable.Rows[i - 1]["FirstEntry"] = ddl1.SelectedValue;
                            dtCurrentTable.Rows[i - 1]["SecondEntry"] = ddl2.SelectedValue;
                            dtCurrentTable.Rows[i - 1]["FirstTextBox"] = txt1.Text;
                            dtCurrentTable.Rows[i - 1]["SecondTextBox"] = txt2.Text;                            
                            rowIndex++;
                        }
                        dtCurrentTable.Rows.Add(drCurrentRow);
                        ViewState["applicationDetail"] = dtCurrentTable;
                        GridView1.DataSource = dtCurrentTable;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }
                //Set Previous Data on Postbacks
                SetPreviousData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SetPreviousData()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["applicationDetail"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["applicationDetail"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            DropDownList ddl1 = GridView1.Rows[rowIndex].FindControl("ddlFirstEntry") as DropDownList;
                            DropDownList ddl2 = GridView1.Rows[rowIndex].FindControl("ddlSecondEntry") as DropDownList;
                            TextBox txt1 = GridView1.Rows[rowIndex].FindControl("txtFirstTextBox") as TextBox;
                            TextBox txt2 = GridView1.Rows[rowIndex].FindControl("txtSecondTextBox") as TextBox;
                            ddl1.SelectedValue = dtCurrentTable.Rows[i]["FirstEntry"].ToString();
                            ddl2.SelectedValue = dtCurrentTable.Rows[i]["SecondEntry"].ToString();
                            txt1.Text = dtCurrentTable.Rows[i]["FirstTextBox"].ToString();
                            txt2.Text = dtCurrentTable.Rows[i]["SecondTextBox"].ToString();
                            rowIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
