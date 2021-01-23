    void loaddata()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDatabaseConnectionString"].ConnectionString);
            SqlCommand command = new SqlCommand();
            connection.Open();
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                GridView1.DataSource = datatable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int employee_id;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDatabaseConnectionString"].ConnectionString);
            SqlCommand command = new SqlCommand();
            connection.Open();
            try
            {
                command = connection.CreateCommand();
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    employee_id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                    command.CommandText = "DELETE FROM Employees WHERE EmployeeID = '" + employee_id + "'";
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            loaddata();
        }
