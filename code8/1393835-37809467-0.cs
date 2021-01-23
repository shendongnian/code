    public class MyObject
    {
        public int MeterID { get; set; }
        public string Datum { get; set; }
        public int NumberOfValues { get; set; }
        public MyObject(int meterID, string datum, int numberOfValues)
        {
            this.MeterID = meterID;
            this.Datum = datum;
            this.NumberOfValues = numberOfValues;
        }
    }
    public class MyObjectEqualityComparer : EqualityComparer<MyObject>
    {
        public override bool Equals(MyObject x, MyObject y)
        {
            return x.MeterID == y.MeterID
                && x.Datum == y.Datum;
        }
        public override int GetHashCode(MyObject obj)
        {
            return obj.MeterID ^ obj.Datum.GetHashCode();
        }
    }
