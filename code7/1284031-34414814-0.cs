    int size = 0; // or declare expected type
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["batch"].ConnectionString))
    {
        size = FileBusinessLogic.LoadBatchAvgFileSizes(connection); // size is a list
    }
    // noew you hane an access to your variable.
