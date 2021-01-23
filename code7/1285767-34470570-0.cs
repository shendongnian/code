    string[] proxy_l = prx.FindElementById("proxylisttable").Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
    
    var proxyInfos = proxy_l
    	.Where(l => l.Contains(" US "))
    	.Select(l => l.Split(' '))
    	.Select(tokens => new
    	{
    		IP = tokens[0],
    		Port = tokens[1]
    	})
    	.ToList();
    
    using (MySqlConnection cn = new MySqlConnection())
    {
    	foreach (var proxyInfo in proxyInfos) {
    		using (MySqlCommand cm = cn.CreateCommand())
    		{
    			cm.CommandText = "insert into proxy_list(ip, port) values(@ip, @port);";
    			cm.Parameters.AddWithValue("@ip", proxyInfo.IP);
    			cm.Parameters.AddWithValue("@port", proxyInfo.Port);
    			cm.ExecuteNonQuery();
    		}
    	}
    }
