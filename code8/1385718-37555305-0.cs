    byte[] imgBuffer = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    MySqlCommand query = new MySqlCommand();
    query.Connection = _connection;
    query.CommandText = "INSERT INTO Photos(id,img) VALUES(?id,?img)";
    var id = Guid.NewGuid();
    query.Parameters.Add("?id", MySqlDbType.Binary).Value = id.ToByteArray();
    query.Parameters.Add("?img", MySqlDbType.Blob).Value = imgBuffer;
    query.ExecuteNonQuery();
