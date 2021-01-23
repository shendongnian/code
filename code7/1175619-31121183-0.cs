     DataTable myDataTable = new DataTable();
            
            using (SqlConnection myConnection = new SqlConnection(yourDBconn)
            {
                    myConnection.Open();
                    using (SqlDataAdapter myAdapter = new SqlDataAdapter(strYourQuery, myConnection))
                    {
                        myAdapter.Fill(myDataTable);
                    }
                }
            }
