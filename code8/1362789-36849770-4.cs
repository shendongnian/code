    class FlightComparer : EqualityComparer<FlightSegment>
    {
        public override bool Equals(FlightSegment x, FlightSegment y)
        {
            return x.ClassName == y.ClassName;
        }
        public override int GetHashCode(FlightSegment obj)
        {
            return obj.ClassName.GetHashCode();
        }
    }
