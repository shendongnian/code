        public interface IConcurrencyEnabled
    {
        byte[] RowVersion { get; set; }
    }
      public class Product : AuditableEntity<Guid>,IProduct,IConcurrencyEnabled
    {
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        private byte[] _rowVersion = new byte[8];
        public byte[] RowVersion
        {
            get
            {
                return _rowVersion;
            }
            set
            {
                System.Array.Copy(value, _rowVersion, 8);
            }
        }
    }
