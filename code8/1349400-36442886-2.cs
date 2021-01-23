    //Ternary-Expression
    List<List<string>> NewBuckets = new List<List<string>>(Int32.MaxValue / 2 < this._Buckets.Count ? Int32.MaxValue : this._Buckets.Count * 2);
    //Classic if-else
    List<List<string>> NewBuckets = null;
    if (Int32.MaxValue / 2 < this._Buckets.Count)
        NewBuckets = new List<List<string>>(Int32.MaxValue);
    else
        NewBuckets = new List<List<string>>(this._Buckets.Count * 2);
