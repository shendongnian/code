    class PointObject
    {
        public double _bearing = 0;
        public double _distance = 0;
        public double _longitude = 0;
        public double _latitude = 0;
        public bool _isStop = false;
        public int _layoverLength = 0;
    
        public PointObject()
        {
            _longitude = 0;
            _latitude = 0;
            _bearing = 0;
            _distance = 0;
            _isStop = false;
            _layoverLength = 0;
        }
    
        public PointObject(double lon, double lat, double dist, double bear, bool stop, int layover)
        {
            _longitude = lon;
            _latitude = lat;
            _distance = dist;
            _bearing = bear;
            _isStop = stop;
            _layoverLength = layover;
        }
    }
