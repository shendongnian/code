        using (SqlConnection sqlConnection1 = new SqlConnection(
                                "Data Source=ORLANDOSQL1;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read()
                    {
                        // Create an instance of your model object,
                        // fill it from the reader, then add it to the collection
                        // of model objects
                    }
                }
            }
        }
  
