    class FlightComparer : IEqualityComparer<FlightSegment>
    {
        public bool Equals(FlightSegment x, FlightSegment y)
        {
            return x.ClassName == y.ClassName;
        }
        public int GetHashCode(FlightSegment obj)
        {
            return obj.ClassName.GetHashCode();
        }
    }
