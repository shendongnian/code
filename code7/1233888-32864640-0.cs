        public Dictionary<string, string> CreateDictionaryRow(string[] row)
        {
            return this.Layout.Items.ToDictionary(item => item.ColumnNameID, 
                                        item => GetValue(item, row));;
        }
        private string GetValue(ColumnMappingBO item, string[] row)
        {
            string value = string.Empty;
            if (!string.IsNullOrEmpty(item.ColumnPosition))
            {
                if (item.ColumnPosition == "ZZ")
                {
                    value = string.Empty;
                }
                else
                {
                    if (LayoutPosition.TryGetValue(item.ColumnID, out Ordinal))
                    {
                        if (row.Length > Ordinal)
                        {
                            if (row[Ordinal] != null)
                            {
                                value = row[Ordinal];
                            }
                        }
                    }
                }
            }
            return value;
        }
