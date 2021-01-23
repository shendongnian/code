        { ExternalOrders = "Data From External Orders in CSV",
          CsvFormat = { CsvFieldSeparator = ",",
                     DecimalSeparator = ".",
                     DateFormat = "yyyy-MM-dd",
                     DateTimeFormat = "yyyy-MM-dd hh:mm:ss",
                     TimeFormat = "hh:mm:ss" },
          ColumnMap = {
               Column1 = { SourceColumnName = "OrderID",
                           SourceColumnType = "nvarchar(50)"
                           StagingColumn = 1 },
               Column2 = { SourceColumnName = "OrderDate",
                           SourceColumnType = "date"
                           StagingColumn = 2 },
               ColumnAmount = { SourceColumnPosition = 5,
                           SourceColumnType = "decimal(18,6)"
                           StagingColumn = 3 }
               },
        StagingImportSql = "INSERT INTO Orders (Number, OrdDate, Amount)
                                SELECT c1, c2, c3
                                    FROM StagingTable
                                    WHERE ImportID = {{ImportIDToken}};"
        }
 
        * these can be in database, in text configuration file, wherever
 
