     string connstring;
                connstring = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;
                SqlConnection conn = new SqlConnection(connstring);
                SqlCommand cmd = new SqlCommand("dbo.GetSemesters", conn);
                conn.Open();
               DataTable dt  = new DataTable();
               dt = cmd.ExecuteReader();
               if (dt.Rows.Count > 0)
               {
                DDSemesters.DataSource = dt;
                DDSemesters.DataTextField = "semesterName";
                DDSemesters.DataValueField = "semesterId";
                DDSemesters.DataBind();
                }
                conn.Close();
                conn.Dispose();
                DDSemesters.Items.Insert(0, "Select Semester");
