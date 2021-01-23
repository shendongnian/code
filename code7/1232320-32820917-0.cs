    string conStr = ConfigurationManager.ConnectionStrings["Code_Churn_Analyiser.Properties.Settings.SVN_ConnectionString"].ConnectionString;
    using(var con = new SqlConnection(conStr))
    {
        // ...
    }
