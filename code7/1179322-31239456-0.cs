    // this is common function for all datatable
            public DataTable ExecuteDataTable(SqlParameterCollection ObjParams, string StoredProcedureName)
            {
                DataTable Obj = new DataTable();
    
                try
                {
                    SqlConnection _oconn = new SqlConnection();
    
                    _oconn.ConnectionString = _connectionString;
                    _oconn.Open();
    
                    SqlCommand ocmd = new SqlCommand();
                    ocmd.Connection = _oconn;
                    ocmd.CommandText = StoredProcedureName;
                    ocmd.CommandType = CommandType.StoredProcedure;
    
                    foreach (SqlParameter item in ObjParams)
                        ocmd.Parameters.Add(item);
                    
    
                    var da = new SqlDataAdapter(ocmd);
                    da.Fill(Obj);
    
                    _oconn.Close();
                }
                catch (Exception)
                {
                    throw;
                }
    
                return Obj;
            }
    
    
            // You can write every diffrenet Procedure with different functions 
            public DataTable GetStudents()
            {
                SqlParameterCollection objParams = new SqlParameterCollection();
                objParams.Add(new SqlParameter("@Name", "ABS"));
                objParams.Add(new SqlParameter("ID", 123));
                var StudentsTable = ExecuteDataTable(objParams, "procname");
            }
