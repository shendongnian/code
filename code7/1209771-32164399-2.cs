        private void SaveGridViewDataIntoDataTable()
		{
			DataTable StudentTable = ViewState["StudentTable"] as DataTable;
			foreach (GridViewRow row in gvStudent.Rows)
			{
				//get ddl value
				DropDownList  DropDownListAddress = row.FindControl("DropDownListAddress") as DropDownList;
				StudentTable.Rows[row.RowIndex]["Address"] = DropDownListAddress.SelectedValue;
				
				//get name from textbox
				TextBox TextBoxName = row.FindControl("TextBoxName") as TextBox;
				StudentTable.Rows[row.RowIndex]["Name"] = TextBoxName.Text;
			}
			ViewState["StudentTable"] = StudentTable;
		}
		private void AddNewRowToGridView()
		{
			SaveGridViewDataIntoDataTable();
			DataTable StudentTable = ViewState["StudentTable"] as DataTable;
			StudentTable.Rows.Add("Name", "Select");
			gvStudent.DataSource = StudentTable;
			gvStudent.DataBind();
		}
