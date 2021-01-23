    public DataTable DisplayProductParameter()
        {
            string getProductIdParam = "DisplayProductParameter";
            var command = Connection.InitSqlCommand(getProductIdParam, CommandType.StoredProcedure);
         -->command.Parameters.AddWithValue("@id", P.Id); 
            return Connection.GetData(command);
        }
and run in **debugging mode** to see what the value of P.Id is. It could be passing a null or empty string value into the procedure.
