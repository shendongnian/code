    private static string ConnSite;
    private static string ConnCms;
    private void SetTargetDB(TargetDB value)
    {
        ConnCms = ConnectionStrings.ConnCms;
        ConnSite = = ConnectionStrings.ConnSite;
        switch (value)
        {
            case TargetDB.MainDB:
                connectionString = ConnectionStrings.isCms? ConnCms : ConnCms2 ;
                break;
            case TargetDB.UsersMaariv:
                connectionString = ConnUser;
                break;
            case TargetDB.JpostUsers:
                connectionString = ConnUser;
                break;
        }
    }
