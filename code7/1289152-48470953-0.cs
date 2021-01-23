        public static List<T> RetrieveMany<T>(this CloudTable table, string partitionKey, 
            string propertyName, IEnumerable<string> valuesRange, 
            List<string> columnsToSelect = null)
            where T : TableEntity, new()
        {
            var enitites = table.ExecuteQuery(new TableQuery<T>()
                .Where(TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition(
                        nameof(TableEntity.PartitionKey),
                        QueryComparisons.Equal,
                        partitionKey),
                    TableOperators.And,
                    GenerateIsInRangeFilter(
                        propertyName,
                        valuesRange)
                ))
                .Select(columnsToSelect))
                .ToList();
            return enitites;
        }
        public static string GenerateIsInRangeFilter(string propertyName, 
             IEnumerable<string> valuesRange)
        {
            string finalFilter = valuesRange.NotNull(nameof(valuesRange))
                .Distinct()
                .Aggregate((string)null, (filterSeed, value) =>
                {
                    string equalsFilter = TableQuery.GenerateFilterCondition(
                        propertyName,
                        QueryComparisons.Equal,
                        value);
                    return filterSeed == null ?
                        equalsFilter :
                        TableQuery.CombineFilters(filterSeed,
                                                  TableOperators.Or,
                                                  equalsFilter);
                });
            return finalFilter ?? "";
        }
