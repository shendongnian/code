    var dataReader = new CsvDataReader("pathToYourCsv",
                new List<TypeCode>(4)
                {
                    TypeCode.String, //IdProduit
                    TypeCode.DateTime, //Mois
                    TypeCode.Double, //Reel
                    TypeCode.Double //Budget
                });
            this.bulkCopyUtility.BulkCopy("tableName", dataReader);
