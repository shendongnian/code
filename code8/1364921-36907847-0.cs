    public class X : IMetadataColumnsWritable
    {
        public int Id
        {
            get;
            set;
        }
        int IMetadataColumns.Id
        {
            get
            {
                return this.Id; // this will call the public `Id` property
            }
        }
    }
