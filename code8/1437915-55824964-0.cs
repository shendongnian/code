    System.Collections.Generic.Dictionary<string, IConnectionFactory> dict = 
        new System.Collections.Generic.Dictionary<string, IConnectionFactory>(
            System.StringComparer.OrdinalIgnoreCase);
    dict.Add("ReadDB", new ConnectionFactory("connectionString1"));
    dict.Add("WriteDB", new ConnectionFactory("connectionString2"));
    dict.Add("TestDB", new ConnectionFactory("connectionString3"));
    dict.Add("Analytics", new ConnectionFactory("connectionString4"));
    dict.Add("LogDB", new ConnectionFactory("connectionString5"));
