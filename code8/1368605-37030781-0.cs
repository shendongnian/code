    while(reader.Read())
    {
        Details hosts = new Details();
        hosts.HostID = reader["hostID"].Tostring();
        hosts.HostNames = reader["hostName"].Tostring();
        data.Inform.Add(hosts);
    }
