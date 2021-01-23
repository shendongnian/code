        protected void submit_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    foreach (GridViewRow row in Gridview1.Rows)
                    {
                        StringCollection sc = new StringCollection();
                        
                        TextBox box1 = (TextBox)row.FindControl("TextBox4");
                        TextBox box2 = (TextBox)row.FindControl("TextBox1");
                        TextBox box3 = (TextBox)row.FindControl("TextBox2");
                        TextBox box4 = (TextBox)row.FindControl("TextBox3");
                        DropDownList ddl1 = (DropDownList)row.FindControl("ddl1");
                        
                        sc.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", firstName.Text, lastName.Text, email.Text, phone.Text, box1.Text, box2.Text, box3.Text, box4.Text, ddl1.SelectedItem.Text));
                        InsertRecords(sc);
                    }
                }
            }
        }
        
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }
        private void InsertRecords(StringCollection sc)
        {
            foreach (string item in sc)
            {
                if (item.Contains(","))
                {
                    string[] splitItems = item.Split(",".ToCharArray());
                    string sqlStatement =
                        "INSERT INTO Traveler_Management.dbo.traveler (FirstName, LastName, Email, Phone, FlightNo, ArrivalDate, DepartureDate, Country, City) VALUES (@firstName, @lastName, @email, @phone, @TextBox4, @TextBox1, @TextBox2,  @ddl1, @TextBox3)";
                    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(sqlStatement, connection))
                        {
                            command.CommandType = CommandType.Text;
                            command.Parameters.AddWithValue("@firstName", splitItems[0]);
                            command.Parameters.AddWithValue("@lastName", splitItems[1]);
                            command.Parameters.AddWithValue("@email", splitItems[2]);
                            command.Parameters.AddWithValue("@phone", splitItems[3]);
                            command.Parameters.AddWithValue("@TextBox4", splitItems[4]);
                            command.Parameters.AddWithValue("@TextBox1", splitItems[5]);
                            command.Parameters.AddWithValue("@TextBox2", splitItems[6]);
                            command.Parameters.AddWithValue("@ddl1", splitItems[7]);
                            command.Parameters.AddWithValue("@TextBox3", splitItems[8]);
                            try
                            {
                                command.ExecuteNonQuery();
                                lblMessage.Text = "Records successfully saved!";
                            }
                            catch (Exception ex)
                            {
                                lblMessage.Text = "There was an error saving the record.";
                                //Code here to handle the exception however you want to do that
                            }
                        }
                        connection.Close();
                    }
                }
            }
        }
