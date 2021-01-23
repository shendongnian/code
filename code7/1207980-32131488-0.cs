    List<foo> foos = new List<AdLookup.foo>();
    NpgsqlConnection conn = new NpgsqlConnection(ConnectionString);
    conn.Open();
    NpgsqlCommand cmd = new NpgsqlCommand(
        "select * from foo where macaddress = :macAddress", conn);
    cmd.Parameters.Add("macAddress", NpgsqlTypes.NpgsqlDbType.MacAddr);
    cmd.Parameters[0].Value = PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF");
    NpgsqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        foo f = new foo();
        f.ipaddress = (IPAddress)reader.GetValue(0);
        f.macaddress = (PhysicalAddress)reader.GetValue(1);
        foos.Add(f);
    }
    reader.Close();
    conn.Close();
