    public interface IDataTable
    {
        IEnumerable Columns { get; set; }
    }
    
    public interface IDataTable<IColumnDef> : IDataTable
    {
        IEnumerable<IColumnDef> Columns { get; set; }
    }
    
    public class DataTableBase<TColumnDef> : IDataTable<TColumnDef>
    {
        public virtual IEnumerable<TColumnDef> Columns { get; set; }
        public virtual IEnumerable IDataTable.Columns
        {
             get { return this.Columns; }
             set { return this.Columns = value.Cast<TColumnDef>() } // possible problem
                           //but f.e. you can forbide setting prop for non-generic version
        }
    }
    
    public class DataTableBase :DataTableBase<IColumnDefinition> 
    {
    }
        
    public class AngularDataTable : DataTableBase<IAngularColumnDefinition>
    {
    }
