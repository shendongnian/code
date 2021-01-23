    public class Base
    {
        public int ID
        {
            get
            {
                return GetType().MetadataToken;
            }
        }
    }
