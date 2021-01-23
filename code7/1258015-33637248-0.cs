    [Target("DatabaseModelEventLogger")]
    public class SqlStoredProcedureTarget : TargetWithLayout
    {
        //removed for brevity...
        public SqlStoredProcedureTarget()
        {
            this.Parameters = new List<DatabaseParameterInfo>();
        }
        /// <summary>
        /// Gets the collection of parameters. Each parameter contains a mapping
        /// between NLog layout and a database named or positional parameter.
        /// </summary>
        /// <docgen category='SQL Statement' order='12' />
        [ArrayParameter(typeof (DatabaseParameterInfo), "parameter")]
        public IList<DatabaseParameterInfo> Parameters { get; private set; }
        //removed for brevity...
    }
