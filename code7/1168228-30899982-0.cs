    public string Width
    {
       get { return _width; }
       set 
           {
              int result;
              int.TryParse(width, out result);
              _width = (result < 0 ? result *-1 : result).ToString();   
              PropertyChanged("Width");
           } 
    }
