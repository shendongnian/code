     DataTable myDataTable = new DataTable();
            
            using (SqlConnection myConnection = new SqlConnection(yourDBconn)
            {
                    yourDBconn.Open();
                    using (SqlDataAdapter myAdapter = new SqlDataAdapter(strYourQuery, yourDBconn))
                    {
                        myAdapter.Fill(myDataTable);
                    }
                }
            }
