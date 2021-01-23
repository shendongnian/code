    public partial class Entities : DbContext
    {
        public Entities(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        public void Close()
        {
            this.Dispose();
        }
    }
