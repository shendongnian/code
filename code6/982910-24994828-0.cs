    IEnumerator<int> e = Enumerable.Range(4, 2).GetEnumerator();
    e.MoveNext(); //returns true
    e.Current;    //returns 4
    e.MoveNext(); //returns true
    e.Current;    //returns 5
    e.MoveNext(); //returns false
