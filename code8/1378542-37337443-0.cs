            var sparkConf = new SparkConf().SetAppName(appName).SetMaster(sparkMaster);
            var sc = new SparkContext(sparkConf);
            var sqlContext = new SqlContext(sc);
            var pf = sqlContext.Read().Parquet(hdfsDataUri + "test.parquet");
            pf.RegisterTempTable("test");
