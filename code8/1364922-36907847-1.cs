    public class X : IMetadataColumnsWritable
    {
        public int Id
        {
            get;
            set;
        }
        // only necessary if you have to differentiate on the implementation.
        int IMetadataColumns.Id
        {
            get
            {
                return this.Id; // this will call the public `Id` property
            }
        }
    }
