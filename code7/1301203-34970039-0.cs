    foreach (DataTable dt in ds.Tables)
            {
                if (dt.Columns.Contains("ExpiryDate"))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["ExpiryDate"] = DateTime.Parse((dr["ExpiryDate"].ToString())).Date;
                    }
                }
            }
