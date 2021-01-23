      protected void txtEditedEmployeeID_TextChanged(object sender, EventArgs e)
      {
          DatabaseManager dbManager = Common.GetDbManager();
          TextBox txt = sender as TextBox; // Edited TextBox
          GridViewRow row = (txt.NamingContainer as GridViewRow);// Row of Edited TextBox
          TextBox txtEmployee= (TextBox)row.FindControl("txtEmployeeID");
          string personID = txtEmployee.Text;
          DataSet dsRE = dbManager.GetEmployeeNameByID(personID);
          for (int i = 0; i < dsRE.Tables[0].Rows.Count; i++)
            {
              string employeeFirstName = dsRE.Tables[0].Rows[i]["FIRST_NAME"].ToString();
              string employeeLastName = dsRE.Tables[0].Rows[i]["LAST_NAME"].ToString();
              ((TextBox)row.FindControl("txtEmployeeName")).Text = staffLastName + " " + staffFirstName;
            }
      }
