    public object this[int index]
    {
       get {
          if (index >= 0 && index <= _objectList.Count - 1 )
              throw new IndexOutOfRangeException();
         // your logic here .....
        }
     }
