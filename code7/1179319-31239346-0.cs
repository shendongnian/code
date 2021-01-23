            SqlConnection cnResult = new SqlConnection(strConnectString);
            SqlDataAdapter daResult = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                daResult.SelectCommand = new SqlCommand();
                daResult.SelectCommand.CommandType = CommandType.StoredProcedure;
                daResult.SelectCommand.CommandText = strSchema + "." + strStoreProcName;
                daResult.SelectCommand.Connection = cnResult;
                daResult.SelectCommand.CommandTimeout = 0;
                //Form Param
                for (int i = 0; i < arlParamName.Count; i++)
                {
                    daResult.SelectCommand.Parameters.Add(new SqlParameter(arlParamName[i].ToString(), arlParamValue[i].ToString()));
                }
                cnResult.Open();
                daResult.Fill(ds);
            }
            catch (Exception e)
            {
                strErrMsg = e.Message;
            }
            finally
            {
                if (cnResult.State.ToString() == System.Data.ConnectionState.Open.ToString())
                    cnResult.Close();
                daResult.Dispose();
            }
            return ds;
        }
