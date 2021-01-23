            Connstr = "Data Source = " + SelectedIP + "; Initial Catalog = " + dbName + "; User ID = " + txtUsername.Text +"; Password = "+ txtPassword.Text +"";
            conn = new SqlConnection(Connstr);
            try
            {
                string contents = "SELECT * FROM ..."
                conn.Open();
                SqlDataAdapter da_1 = new SqlDataAdapter(contents, conn);   //create command using contents of sql file
                da_1.SelectCommand.CommandTimeout = 120; //set timeout in seconds
                DataSet ds_1 = new DataSet(); //create dataset to hold any errors that are rturned from the database
                try
                {
                    //manipulate database
                    da_1.Fill(ds_1);
                    if (ds_1.Tables[0].Rows.Count > 0) //loop through all rows of dataset
                    {
                       for (int i = 0; i < ds_1.Tables[0].Rows.Count; i++)
                        {
                                                //rows[rownumber][column number/ "columnName"]
                            Console.Write(ds_1.Tables[0].Rows[i][0].ToString() + " ");
                        }
                    }
                 }
                 catch(Exception err)
                 {}
             conn.Close();
          }
          catch(Exception ex)
          {}
