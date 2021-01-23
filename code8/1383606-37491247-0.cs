    public class MyContext : DbContext
    {
        public MyContext()
            : base()
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += (sender, e) =>
            {
                TrimStringValues(Entry(e.Entity));
            };
        }
    
        void TrimStringValues(DbEntityEntry entry)
        {
            foreach (var property in entry.CurrentValues.PropertyNames)
            {
                var currentValue = entry.CurrentValues[property] as string;
                if (currentValue != null)
                    entry.CurrentValues[property] = currentValue.Trim();
            }
        }
    }
