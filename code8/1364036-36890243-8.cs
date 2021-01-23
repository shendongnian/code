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
    
    private static void ProcessItem(Dependency target, List<Dependency> dictionary)
    {
        if(target.Dependencies != null)
            foreach(var dep in target.Dependencies)
            {
                var children = dictionary.Where(x => x.TableName == dep.TableName).FirstOrDefault();
                dep.Dependencies = children == null ? null : children.Dependencies;
                ProcessItem(dep, dictionary);
            }
    }
    
    public static List<Dependency> ProcessItems(List<Link> links)
    {
        var initial = links.GroupBy(x => new { x.RefTable, x.RefColumn })
            .Select(x => new Dependency {
                TableName = x.Key.RefTable,
                ColumnName = x.Key.RefColumn,
                Dependencies = x.Select(y => new Dependency {
                    TableName = y.Table,
                    ColumnName = y.Column
                }).ToList()
            }).ToList();
        var js = new JavaScriptSerializer();
        var temp = js.Deserialize<List<Dependency>>(js.Serialize(initial));        
        initial.ForEach(x => ProcessItem(x, temp));
        return initial;
    }
