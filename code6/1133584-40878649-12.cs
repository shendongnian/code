               public static IEnumerable<string> GetColumnNames(this IDataReader reader)
                    {
                        var schemaTable = reader.GetSchemaTable();
                        return schemaTable == null
                            ? Enumerable.Empty<string>()
                            : schemaTable.Rows.OfType<DataRow>().Select(row => row["ColumnName"].ToString());
                    }
