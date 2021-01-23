    using (SqlDataReader dataReader = command.ExecuteReader())
    {
        MyObject o = new MyObject()
        while (dataReader.Read())
        {
            o.Name = dataReader.GetString(0);
            var number = dataReader.GetValue(1);
            
            try
            {
                o.Number = Convert.ToInt64(number);
            }
            catch(InvalidCastException)
            {
                Throw new Exception("Underlying DataType is not convertable to int 64.");
            }
        }
    }
