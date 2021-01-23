     string conStr = "...";
                SqlConnection sqlConnection = new SqlConnection(conStr);
                string sqlString = "SELECT name, startdate FROM table WHERE startdate > @end_date AND name = ...";
                SqlDataAdapter da = new SqlDataAdapter(sqlString, sqlConnection);
                da.SelectCommand.Parameters.AddWithValue("@end_date", DateTime.Now);
                DataTable dt = new DataTable();
                da.Fill(dt);
    
                Tournament.DataSource = dt;
                Tournament.DataBind();
            }
