    using (SqlConnection conn = new SqlConnection(connStr))
    {
        // Establish the connection with the database
        conn.Open();
    
        using (SqlCommand query = new SqlCommand("SELECT * from table", conn))
        {
            query.CommandType = CommandType.Text;
            using (var rst = query.ExecuteReader())
            {
                while (rst.Read())
                {
                    strProcesses.AppendFormat("<process name='{1}' id='{0}' />", rst[0], rst[1]);
                    strTasks.AppendFormat("<task name='{0}' processid='{1}' start='{2}' end='{3}' />", rst[4], rst[0], rst[2], rst[3]);
                }
            }
        }
        DateTime today = DateTime.Now;
        xmlStr.Append("<trendlines><line start='" + DateTime.DaysInMonth(today.Year, today.Month) + "/" + today.Month + "/" + today.Year + "' displayvalue='Heute'/></trendlines>");
        // End the XML string
        xmlStr.Append("<categories>" + strCategories.ToString() + "</categories> <processes>" + strProcesses.ToString() + "</processes> <tasks width='10'>" + strTasks.ToString() + "</tasks> </chart>");
        conn.Close();
    }
