    public interface BuildClassBase<TClass> : IBuildClass<TClass>
    {
        public BuildClassBase(SqlConnection connection)
        {
            Connection = connection;
        }
        
        public async IEnumerable<TClass> BuildAsync(double id)
        {
            //Execute query and pass results to InnerBuid
            return InnerBuildAsync(/*Pass DataTable*/);
        }
        public abstract async IEnumerable<TClass> InnerBuildAsync(DataTable data);
        //Ctor of each derived class will set the value
        public string Query { get; protected set; }
        public SqlConnection Connection {get; set; }
    }
