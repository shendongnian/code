    string sql = "UPDATE APPOINTMENTS Set [CustomerID]=@id,[DateTime]=@dateTime,[Time]=@time WHERE [CustomerID]=@customerid";
    using (OleDbConnection  cn = new OleDbConnection("Your connection string here"))
            {
                using (OleDbCommand cmd = new OleDbCommand(sql,cn))
                {
                    cmd.Parameters.Add("@id", OleDbType .VarChar, 50).Value = "Some value Here";
                    cmd.Parameters.Add("@dateTime", OleDbType.Date).Value = "Some value Here";
                    cmd.Parameters.Add("@time", OleDbType.DBTime, 50).Value = "Some value Here";
                    cmd.Parameters.Add("@customerid", OleDbType .VarChar, 50).Value = "Some value Here";
                    //execute command here
                }
            }
