         protected void gridview_f_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="GetFile")
            {
                string[] ca = e.CommandArgument.ToString().Split('|');
                SqlConnection objSqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);
                objSqlCon.Open();
                SqlTransaction objSqlTran = objSqlCon.BeginTransaction();
                SqlCommand objSqlCmd = new SqlCommand("spGet_getMyFile", objSqlCon, objSqlTran);
                objSqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter objSqlParam1 = new SqlParameter("@ID", SqlDbType.VarChar);
                objSqlParam1.Value = ca[0]; // e.CommandArgument;
                objSqlCmd.Parameters.Add(objSqlParam1);
                
                string path = string.Empty;
                using (SqlDataReader sdr = objSqlCmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        path = sdr[0].ToString();
                    }
                }
                objSqlCmd = new SqlCommand("SELECT GET_FILESTREAM_TRANSACTION_CONTEXT()", objSqlCon, objSqlTran);
                byte[] objContext = (byte[])objSqlCmd.ExecuteScalar();
                SqlFileStream objSqlFileStream = new SqlFileStream(path, objContext, FileAccess.Read);
                byte[] buffer = new byte[(int)objSqlFileStream.Length];
                objSqlFileStream.Read(buffer, 0, buffer.Length);
                objSqlFileStream.Close();
                objSqlTran.Commit();
                Response.AddHeader("Content-disposition", "attachment; filename=" + ca[1]);
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(buffer);
            }
        }
