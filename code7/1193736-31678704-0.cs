        public List<int> GetSomething(Day day)
        {
            var dbc = new Context();
            switch (day)
            {  
                case MONDAY: return  GetResult(dbc.table1, dbc );
                case FRIDAY: return  GetResult(dbc.table2, dbc);
            }
        }
       
        public List<int> GetResult<T>(DbSet<T> table, Context context) where T : class, MyInterface
        {
            List<int> results = (from day in table
                        join model in context.OtherTable on ...
                        select id).ToList();
            return results;
        }
