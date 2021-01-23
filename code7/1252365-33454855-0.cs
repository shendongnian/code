    SqlDataReader DR = ExecuteReader(System.Data.CommandType.Text, "Select Sum(Price) From Tbl_Cost Where Dat Between @F AND @L", new SqlParameter[]
                {
                    new SqlParameter("@F", firstDayOfMonth),
                    new SqlParameter("@L", lastDayOfMonth),
                }
