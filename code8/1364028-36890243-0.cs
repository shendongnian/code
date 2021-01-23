    public class Link
    {
        public string FKName { get; set; }
        public string SchemaName { get; set; }
        public string Table { get; set; }
        public string Column { get; set; }
        public string RefTable { get; set; }
        public string RefColumn { get; set; }
    }
    
    public class Dependency
    {
        public string TableName { get; set; } // RefTable
        public string ColumnName { get; set; } //RefColumn
        public List<Dependency> Dependencies { get; set; } // Table
    }
    
    private static void ProcessItem(Dependency target, List<Dependency> initial)
    {
        if(target.Dependencies != null)
            foreach(var dep in target.Dependencies)
            {
                var children = initial.Where(x => x.TableName == dep.TableName).FirstOrDefault();
                dep.Dependencies = children == null ? null : children.Dependencies;
                ProcessItem(dep, initial);
            }
    }
    
    public static List<Dependency> ProcessItems(List<Link> links)
    {
        var initial = links.GroupBy(x => new { x.Table, x.RefColumn }).Select(x => new Dependency { TableName = x.Key.Table, ColumnName = x.Key.RefColumn, Dependencies = x.Select(y => new Dependency { TableName = y.RefTable, ColumnName = y.Column }).ToList() }).ToList();
        initial.ForEach(x => ProcessItem(x, initial));
        return initial;
    }
