    public class DuplicateKeyRowException : Exception
    {
        public string TableName { get; }
        public string IndexName { get; }
        public string KeyValues { get; }
        public DuplicateKeyRowException(SqlException e) : base(e.Message, e)
        {
            if (e.Number != 2601) 
                throw new ArgumentException("SqlException is not a duplicate key row exception", e);
            var regex = @"\ACannot insert duplicate key row in object \'(?<TableName>.+?)\' with unique index \'(?<IndexName>.+?)\'\. The duplicate key value is \((?<KeyValues>.+?)\)";
            var match = new System.Text.RegularExpressions.Regex(regex, System.Text.RegularExpressions.RegexOptions.Compiled).Match(e.Message);
            Data["TableName"] = TableName = match?.Groups["TableName"].Value;
            Data["IndexName"] = IndexName = match?.Groups["IndexName"].Value;
            Data["KeyValues"] = KeyValues = match?.Groups["KeyValues"].Value;
        }
    }
