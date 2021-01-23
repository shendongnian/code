    public sealed class TableManipulationActivity : CodeActivity<DataTable>
    {
        [Required]
        public InArgument<DataTable> TableInArgument { get; set; }
    
        private DataTable _table;
    
        protected override DataTable Execute(CodeActivityContext context)
        {
            _table = TableInArgument.Get(context);
    
            // play with _table value and do whatever you want [All sorts of CRUD operations]
    
            var result = new DataTable(); // populate this result 
            
            // Manipulate result 
            // ...
            // ...
    
            return result;
        }
    }
