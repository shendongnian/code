    public struct ResultKey : IEquatable<ResultKey>
    {
        public string SensorName { get; set; }
        public string StationName { get; set; }
        public ResultKey(string sensorName, string stationName)
        {
            this.SensorName = sensorName;
            this.StationName = stationName;
        }
        public bool Equals(ResultKey other)
        {
            return string.Equals(SensorName, other.SensorName) && string.Equals(StationName, other.StationName);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ResultKey && Equals((ResultKey)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((SensorName != null ? SensorName.GetHashCode() : 0)*397) ^ (StationName != null ? StationName.GetHashCode() : 0);
            }
        }
        public static bool operator ==(ResultKey left, ResultKey right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(ResultKey left, ResultKey right)
        {
            return !left.Equals(right);
        }
    }
