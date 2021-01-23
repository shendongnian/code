     public DataTable ClientSearch(string Argument, string SearchType)
            {
                Connection.Open();
                string QueryStr = "SELECT ClientName,PostCode,ContactNo FROM Clients WHERE " + SearchType + " LIKE '%" + Argument + "%'";
                DataTable DataT = new DataTable();
                SqlDataAdapter SQLDA = new SqlDataAdapter(QueryStr, Connection);
                SQLDA.Fill(DataT);
                return DataT;
    
            }
