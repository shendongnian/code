     using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=\"Student Extended\";Integrated Security=True"))
                    {
                        SqlCommand command = new SqlCommand
                        {
                            Connection = connection,
                            CommandText = "SELECT DepartmentId,DepartmentName FROM dbo.TblDepartment"
                        };
                        SqlDataAdapter adpater = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adpater.Fill(table);
                        if (txtStdDeptName != null)
                        {
                            txtStdDeptName.DataSource = table;
                            txtStdDeptName.DisplayMember = "DepartmentName";
                            txtStdDeptName.ValueMember = "DepartmentId";
                        }
                    }
