            if (Session["New"] != null)
            {
                if (!IsPostBack)
                {
                    bindgrid();
                }
            }
        }
        private void bindgrid()
        {
            SqlConnection conn = new SqlConnection(connStr);
            dt = new DataTable();
            com.Connection = conn;
            com.CommandText = "SELECT * FROM UserData WHERE Username ='" + Session["New"] + "'";
            sqlda = new SqlDataAdapter(com);
            sqlda.Fill(dt);
            EmployeeFormView.DataSource = dt;
            EmployeeFormView.DataBind();
        }
       
        protected void EmployeeFormView_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            DataKey key = EmployeeFormView.DataKey;
            TextBox txtFirstName = (TextBox)EmployeeFormView.FindControl("txtFirstName2");
            TextBox txtLastName = (TextBox)EmployeeFormView.FindControl("txtLastName2");
            TextBox txtPass = (TextBox)EmployeeFormView.FindControl("txtPassword2");
            TextBox txtAddress = (TextBox)EmployeeFormView.FindControl("txtAddress2");
            TextBox txtZip = (TextBox)EmployeeFormView.FindControl("txtZip2");
            TextBox txtContact = (TextBox)EmployeeFormView.FindControl("txtContact2");
            SqlConnection conn = new SqlConnection(connStr);
            com.Connection = conn;
            com.CommandText = "UPDATE UserData SET FirstName ='" + txtFirstName.Text + "',LastName ='" + txtLastName.Text + "',DeliveryAddress ='" + txtAddress.Text + "', Zip ='"+txtZip.Text+ "',Password ='"+ txtPass.Text+"',ContactNumber ='" + txtContact.Text + "'   WHERE ID ='" + key.Value.ToString() + "'";
            conn.Open();
            com.ExecuteNonQuery();
            Response.Write("Record updated successfully");
            bindgrid();
            conn.Close();
        }
        protected void EmployeeFormView_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            EmployeeFormView.ChangeMode(e.NewMode);
            bindgrid();
            if (e.NewMode == FormViewMode.Edit)
            {
                EmployeeFormView.AllowPaging = false;
            }
            else
            {
                EmployeeFormView.AllowPaging = true;
            }
        }
        
        protected void EmployeeFormView_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            EmployeeFormView.ChangeMode(FormViewMode.ReadOnly);
        }
