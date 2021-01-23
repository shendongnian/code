        public class MyAddressObject
        {
            public int a_code { get; set; }
        }
        public static List<MyAddressObject> GetAddresses(DateTime dtStart, DateTime dtEnd)
        {
            #region Create SqlCommand
            SqlCommand cmd;
            cmd = new SqlCommand("[dbo].[uspGetAddress]");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sdate", dtStart);
            cmd.Parameters.AddWithValue("@edate ", dtEnd);
            #endregion
            #region Talk to the Database
            DataSet objDataSet;
            using (System.Data.SqlClient.SqlConnection objConn = new System.Data.SqlClient.SqlConnection(
                        "My Connection String"))
            {
                cmd.Connection = objConn;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    objDataSet = new DataSet();
                    da.Fill(objDataSet);
                }
            }
            #endregion
            #region Turn the data into a list of MyAddressObjects
            var objResult = from data in objDataSet.Tables[0].AsEnumerable()
                            select new MyAddressObject
                            {
                                a_code = data.Field<int>("a_code")
                            };
            return objResult.ToList();
            #endregion
        }
