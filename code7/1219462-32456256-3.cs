     private bool _condition = false;
     public bool Condition
     {
         get
         {
             return _condition;
         }
         set
         {
             if (_condition == value)
             {
                 return;
             }
             _condition = value;
             OnPropertyChanged();
          }
     }
