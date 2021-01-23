        List persons = new List();
    using (SqlConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=AdventureWorks2014;Integrated Security=SSPI"))
    using (SqlCommand cmd = new SqlCommand("SELECT BusinessEntityID AS ID, FirstName, MiddleName, LastName FROM Person.Person", connection))
    {
        connection.Open();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            // Check is the reader has any rows at all before starting to read.
            if (reader.HasRows)
            {
                
                throw new ApplicationExcetion("Data is duplicated");    
                
            }
        }
    }
