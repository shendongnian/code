        string connstring1 = "Data Source=server1;Initial Catalog=northwind;user=xxx;password=xxx";
        //Serializing an IDataReader into a ProtoBuf:
        Stream buffer = new MemoryStream();
        using (var c1 = new SqlConnection(connstring1))
        {
           c1.Open();
            // Serialize SQL results to a buffer
            using (var command = new SqlCommand("SELECT * FROM products", c1))
            using (var reader = command.ExecuteReader())
                DataSerializer.Serialize(buffer, reader);
            // Deserialize, Read them back
            buffer.Seek(0, SeekOrigin.Begin);
            using (var reader = DataSerializer.Deserialize(buffer))
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["ProductName"]);
                }
            }
        }
    }
