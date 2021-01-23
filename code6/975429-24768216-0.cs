    private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                sqlHelper.sqlconnection.Close();
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                sqlHelper.sqlconnection.Open();
                string search = txtSearch.Text;
                string temp;
                temp = sqlHelper.ReplaceValue(cbxWarehouse.Text, true);
                string tableName = "dbo.db_" + temp;
                SqlDataReader myReader = null;
                
                SqlCommand sql = new SqlCommand("SELECT * FROM " + tableName + " WHERE (StoreNo LIKE'" + search + "') OR " +
                "(Description LIKE '%" + search + "%') OR " +
                "(Name LIKE '%" + search + "%') OR " +
                "(ItemNo LIKE '%" + search + "%') OR " +
                "(StoreName LIKE '%" + search + "') AND Assembly <> 1", sqlHelper.sqlconnection);
                myReader = sql.ExecuteReader();
                DataTable dt = new DataTable();
                for (int i = 0; i < myReader.FieldCount; i++)
                {
                    dt.Columns.Add(myReader.GetName(i), typeof(string));
                }
                try
                {
                    while (myReader.Read())
                    {
                        DataRow row = dt.Rows.Add();
                        for (int i = 0; i < myReader.FieldCount; i++)
                        {
                            string Val = myReader[i].ToString();
                            row[i] = Val;
                        }
                    }
                    myReader.Close();
                }
                finally
                {
                    gridProducts.DataSource = dt;
                }
            }
            catch
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }
        }
