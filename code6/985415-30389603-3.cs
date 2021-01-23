        private string BuildCreateTableCommand(string schema, string tempTableName, IEnumerable<ColumnMapping> properties)
        {
            var pkConstraint = string.Join(", ", properties.Where(p => p.IsPrimaryKey).Select(c => "[" + c.NameInDatabase + "]"));
            var columns = properties.Select(c => "[" + c.NameInDatabase + "] " + c.DataType);
            var pk = properties.Where(p => p.IsPrimaryKey).Any() ? string.Format(", PRIMARY KEY ({0})", pkConstraint) : "";
            var str = string.Format("CREATE TABLE {0}.[{1}]({2} {3})", schema, tempTableName, string.Join(", ", columns), pk);
            return str;
        }
