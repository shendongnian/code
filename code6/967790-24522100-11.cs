     public SettingsPropertyValue this[string name]
     { 
         get
         {
             object pos = _Indices[name];
             if (pos == null || !(pos is int))
                 return null; 
             int ipos = (int)pos;
             if (ipos >= _Values.Count)
                 return null;
             return (SettingsPropertyValue)_Values[ipos];
         }
     } 
