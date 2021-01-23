    public int SelectIndex
    {
       get { return _SelectIndex; }
       set { 
         _SelectIndex = value;
         OnSelectIndexChanged(new SelectEventArgs(value)); 
       }
    }
