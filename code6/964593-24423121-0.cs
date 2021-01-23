            private int UserExistCheck(string alias)
        {
            string query6;
            try
            {
                OpenCnn();
                query6 = "Select count(*) from cntc_employee where emp_alias= '" + alias + "' ";
                cmd = new SqlCommand(query6, con);
                return cmd.ExecuteScalar(); //-- or ExecuteNonQuery()
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseCnn();
            }
        }
