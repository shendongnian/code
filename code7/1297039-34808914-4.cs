    public class LatLon
    {
        public double lat {get;set;}
        public double lon {get;set;}
    }
    class ProximityFilter
    {
        private LatLon m_ref = null;
            
        internal bool DifferentFromPrevious(LatLon arg)
        {
            if (m_ref == null)
            {
                m_ref = arg;
                return true;
            }
            var are_different = Math.Abs(arg.lat - m_ref.lat) > 0.001 || Math.Abs(arg.lon - m_ref.lon) > 0.001;
            if (are_different)
                m_ref = arg;
            return are_different;
        }
    }
    class Program
    {
        static int Main(string[] args)
        {
            var p1 = new LatLon { lat = 49.9429989, lon = 3.9542134 };
            var p2 = new LatLon { lat = 49.9529989, lon = 3.9642134 };
            var p3 = new LatLon { lat = 49.9429989, lon = 3.9542133 };
            var p4 = new LatLon { lat = 49.9429989, lon = 3.9542136 };
            var list = new List<LatLon> {p1, p2, p3, p4};
            var filter = new ProximityFilter();
            var cleaned = list.Where(filter.DifferentFromPrevious);
            // ...
        }
    }
