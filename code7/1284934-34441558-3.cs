    public class DbContextHelper : IDbContextHelper // interface for testing if you need it
    {
        private const string contextKey = "MyContext";
        public MyContext GetContext()
        {
            if (HttpContext.Current.Items[contextKey] == null)
            {
                HttpContext.Current.Items.Add(contextKey, new MyContext());
            }
            return (MyContext) HttpContext.Current.Items[contextKey];
        }
        public void DisposeContext()
        {
            if (HttpContext.Current.Items[contextKey] == null)
            {
                var context = (MyContext) HttpContext.Current.Items[contextKey];
                context.Dispose();
            }
        }
    }
