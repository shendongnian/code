            //C# sample to load SQL Server data as Spark DataFrame using JDBC
            var sparkConf = new SparkConf();
            var sparkContext = new SparkContext(sparkConf);
            var sqlContext = new SqlContext(sparkContext);
            var dataFrame = sqlContext.Read()
                .Jdbc("jdbc:sqlserver://localhost:1433;databaseName=Temp;;integratedSecurity=true;", "xyz",
                    new Dictionary<string, string>());
            dataFrame.ShowSchema();
            var rowCount = dataFrame.Count();
            Console.WriteLine("Row count is " + rowCount);
