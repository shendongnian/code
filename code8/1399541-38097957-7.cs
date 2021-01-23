    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new TestDB())
            {
                var query = ctx.Persons.Include(p => p.Parents).Include(p => p.Children);
                // includes[0] = "Parents"
                // includes[1] = "Children"
                var includes = IncludeVisitor.GetIncludes(query.Expression);
            }
        }
    }
