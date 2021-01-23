                byte[] bt;
                using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=true"))
                {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Photo FROM Employees WHERE EmployeeID=2", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bt = reader["Photo"] as byte[] ?? null;
                            ImageConverter ic = new ImageConverter();
                           System.Drawing.Bitmap img = (System.Drawing.Bitmap)ic.ConvertFrom(bt);
                            pictureBox1.Image = img;
                           
                        }
                    }
                }
            }
