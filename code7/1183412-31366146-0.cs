        decimal GetTotalMaterialCost()
        {
            decimal total = 0;
            using (var con = new SqlConnection(/*connection string if not configured via web.config*/))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText =
                        "SELECT SUM(rm.Quantity * m.SellingPrice) AS TotalMaterialCost FROM Resource_Materials rm " +
                        "JOIN Materials m ON m.MaterialID = rm.MaterialID " +
                        "JOIN ProjectTasks t ON t.TaskID = rm.TaskID " +
                        "WHERE t.TaskID=@TaskID HAVING COUNT (*) > 0";
                    cmd.Parameters.AddWithValue("@TaskID", Request.QueryString["ID"].ToString());
                    object data = cmd.ExecuteScalar();
                    if (data == null)
                        total = 0;
                    else
                        total = (decimal)cmd.ExecuteScalar();
                }
            }
            return total;
        }
