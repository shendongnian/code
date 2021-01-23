    public sealed class OldDbAccess : DbAccess
    {
        protected override MetaData CreateMetaData()
        {
            // return old metadata
        }
    }
    public class DbAccess
    {
        public DbAccess()
        {
            this.MetaData = CreateMetaData();
        }
        protected virtual MetaData CreateMetaData()
        {
            // return new metadata
        }
    }
