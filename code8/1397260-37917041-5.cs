        { ExternalOrders = "Data From External Orders in CSV",
          CsvFormat = { CsvHasHeaderRow = true,
                     CsvFieldSeparator = ",",
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
                                SELECT CAST(c1 AS navarchar(50),
                                        CAST(c2 AS date),
                                        CAST(c3 AS money)
                                    FROM StagingTable
                                    WHERE ImportID = {{ImportIDToken}};"
        }
 
    * this can be in database, in text configuration file, wherever. I have it in 3 database tables (ImportAction, CsvFormat, ColumnMapping)
