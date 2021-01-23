    Interface ISearch<TSchema> where TSchema: ISchema
    {
        TSchema Search(....);   
    }
    class Table : ISearch<TableSchema>
    {
        public TableSchema Search(....)
        {
            //Some searching code
        }
    }
    
    class View:ISearch<ViewSchema>
    {
        public TableSchema Search(....)
        {
            //Some searching code
        }
    }
