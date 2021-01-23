            try
            {
                ListItem lstBox;
                listEmployeeCategory.Items.Clear();
                var query = Wrapper.EmployeeCategory();
                foreach (var items in query)
                {
                    lstBox = new ListItem(items.Description, items.ID.ToString());
                    listEmployeeCategory.Items.Add(lstBox);
                }
            }
            catch(Exception ex)
            {
                lblMessage.Visible = true;
                lblMessage.Style.Add("Color", "Red");
                lblMessage.Text = "Data loading failed "+ ex +" !";
            }
        }
            protected void listEmployeeCategory_SelectedIndexChanged(object sender, EventArgs e)
            {
                lblMessage.Visible = false;
                try
                {
                    Session["ID"] = listEmployeeCategory.SelectedValue.ToString();
                    txtEmpCategoryName.Text = listEmployeeCategory.SelectedItem.ToString();
    
                }
                catch (Exception ex)
                {
                    lblMessage.Visible = true;
                    lblMessage.Style.Add("Color", "Red");
                    lblMessage.Text = "Loading session data failed " + ex + " !";
                }
            }
    
            protected void btnEdit_Click(object sender, EventArgs e)
            {
                try
                {
                    int id = int.Parse(Session["ID"].ToString());
                    Wrapper.UpdateEmpCategory(id, txtEmpCategoryName.Text.Trim());
                    lblMessage.Visible = true;
                    lblMessage.Style.Add("Color", "Green");
                    lblMessage.Text = "Data edited successfully!";
    
                    BindListBox();
                    txtEmpCategoryName.Text = string.Empty;
                }
                catch
                {
                    lblMessage.Visible = true;
                    lblMessage.Style.Add("Color", "Red");
                    lblMessage.Text = "Data editing failed!";
                }
            }
