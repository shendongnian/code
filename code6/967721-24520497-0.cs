    class MyObjectComparerByOtherObjectName : IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject x, MyObject y)
        {
            return x.OtherObjectName == y.OtherObjectName;
        }
        
        public bool GetHashCode(MyObject x)
        {
            return x.OtherObjectName != null ? x.OtherObjectName.GetHashCode() : 0;
        }
    }
    ...
    var distinct = MyObjects.Distinct(new MyObjectComparerByOtherObjectName());
