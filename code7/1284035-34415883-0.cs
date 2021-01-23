        Action<List<int>> handleSize = size =>
        {
            // you can do what you wanna do with size here.
            Console.WriteLine(size);
        };
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["batch"].ConnectionString))
        {
            var size = FileBusinessLogic.LoadBatchAvgFileSizes(connection);  // size is a list
            handleSize(size);
        }
