    var connBuilder = new System.Data.Common.DbConnectionStringBuilder();
    
    connBuilder.Add("Data Source", DataSource);
    connBuilder.Add("User Id", UserId);
    connBuilder.Add("Password", Password);
    if (Providor.Equals(DatabaseProvidors.Oracle)) {
       connBuilder.Add("Persist Security Info", isIntegratedSecuritySet);
       connBuilder.Add("Connection Timeout", ConnectionTimeout);
    } else if (Providor.Equals(DatabaseProvidors.SqlServer)) {
       connBuilder.Add("Integrated Securiry", isIntegratedSecuritySet);
       connBuilder.Add("Connect Timeout", ConnectionTimeout); // Not sure about this property
    }
