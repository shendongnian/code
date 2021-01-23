    public bool SelectAll
    {
       get { return _selectAll;}
       set 
       {
           _selectAll = value;
           RaisPropertyChanged();
           foreach( var item in MyList)
           {
                item.Select = _selectAll;
           }
       }    
    }
