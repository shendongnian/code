    public sealed class XModelInstance
    {
        private static XDBEntities edmx = null;
        private static readonly object padlock = new object();
        private XModelInstance() { }
        public static XDBEntities Edmx
        {
            get
            {
                lock (padlock)
                {
                    if (edmx == null)
                    {
                        edmx = new XDBEntities();
                    }
                    return edmx;
                }
            }
        }
    }
