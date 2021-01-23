    public class MyObjectComparer : Comparer<MyObject>
    {
        public override int Compare(MyObject x, MyObject y)
        {
            return Format(x).CompareTo(Format(y));
        }
        private static string Format(MyObject obj)
        {
            return $"{obj.MeterID}:{obj.Datum}:{obj.NumberOfValues}";
        }
    }
