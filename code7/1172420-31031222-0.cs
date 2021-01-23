     List<string> _data=new List<string>();
    public IEnumerable<string> Data
    {
          get{ return _data;}
          private set{
              _data=value.ToList();
             }
     }
