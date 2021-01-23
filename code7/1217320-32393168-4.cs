    private class MetaInfoValueGroupTag
    {
        private sealed class MetainfoEqualityComparer : IEqualityComparer<MetaInfoValueGroupTag>
        {
            public bool Equals(MetaInfoValueGroupTag x, MetaInfoValueGroupTag y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.metainfo, y.metainfo);
            }
    
            public int GetHashCode(MetaInfoValueGroupTag obj)
            {
                return (obj.metainfo != null ? obj.metainfo.GetHashCode() : 0);
            }
        }
    
        private static readonly IEqualityComparer<MetaInfoValueGroupTag> MetainfoComparerInstance = new MetainfoEqualityComparer();
    
        public static IEqualityComparer<MetaInfoValueGroupTag> MetainfoComparer
        {
            get { return MetainfoComparerInstance; }
        }
    
        private string metainfo;
        //...
    
        public string MetaInfo
        {
            get { return metainfo; }
            set { metainfo = value; }
        }
        //...
    }
