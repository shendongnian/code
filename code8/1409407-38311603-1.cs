    class MyObjectComparer : IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject x, MyObject y)
        {
            return x.ObjectId == y.ObjectId;
        }
        public int GetHashCode(MyObject obj)
        {
            return obj.ObjectId.GetHashCode();
        }
    }
    var MyDictionary = MyList
        .Distinct(new MyObjectComparer())
        .ToDictionary(i => i.ObjectId, i => i);
    
