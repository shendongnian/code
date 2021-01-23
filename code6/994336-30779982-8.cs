        /// <summary>
        /// Return a CSV string of the values in the list
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private string ToParameterCSV(IEnumerable<MySQLFieldDefinition> p, int row)
        {
            string csv = p.Aggregate(string.Empty,
                (current, i) => string.IsNullOrEmpty(current)
                        ? string.Format("@{0}{1}",i.FieldName, row)
                        : string.Format("{0},@{2}{1}", current, row, i.FieldName));
            return string.Format("({0})", csv);
        }
