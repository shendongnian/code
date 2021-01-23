        using (SqlDataReader DT2 = cmd2.ExecuteReader())
        {
            // If the SQL returns any records, process the info
            while(DT2.Read())
            {
                // If there's a BusinessID (aka Business Type), fill it in
                string BizID = (DT2["Business_ID"].ToString());
                if (!string.IsNullOrEmpty(BizID))
                {
                    DDLBustype.SelectedValue = BizID;
                }
            }
        }
