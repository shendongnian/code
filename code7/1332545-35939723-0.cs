    var connBuilder = new System.Data.Common.DbConnectionStringBuilder();
    
    connBuilder.Add("DataSource", DataSource);
    connBuilder.Add("UserID", UserId);
    connBuilder.Add("Password", Password);
    connBuilder.Add("ConnectionTimeout", ConnectionTimeout);
    if (Providor.Equals(DatabaseProvidors.Oracle)) {
       connBuilder.Add("PersistSecurityInfo", isIntegratedSecuritySet);
    } else if (Providor.Equals(DatabaseProvidors.SqlServer)) {
       connBuilder.Add("IntegratedSecurity", isIntegratedSecuritySet);
    }
