    class MyObjectComparer : IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject x, MyObject y)
        {
            return x.ObjectId == y.ObjectId;
        }
    }
    var MyDictionary = MyList
        .Distinct(new MyObjectComparer())
        .ToDictionary(i => i.ObjectId, i => i);
    
