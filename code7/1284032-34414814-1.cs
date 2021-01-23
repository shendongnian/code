    int size = 0; // or declare expected type
    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["batch"].ConnectionString))
    {
        size = FileBusinessLogic.LoadBatchAvgFileSizes(connection); // size is a list
    }
    // now you have access to your variable outside the using scope.
