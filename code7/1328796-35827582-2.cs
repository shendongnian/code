        private void CheckContactNumber()
        {
            
            DataSet myDataSet = new DataSet();
           
            try
            {
                string strAccessSelect = "select count(*) from Employee where ContactNumber='" + addContactNum.Text + "'";
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, conn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);
                conn.Open();
                myDataAdapter.Fill(myDataSet, "Employee");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                conn.Close();
            }
            DataTable dt = myDataSet.Tables[0];
            if (dt != null)
            {
                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    string err = "Contact Number Already exist..";
                }
            }
        }
