                  public override bool Equals(object obj)
                    {
                    
                      return this.Key == ((KeyClass)obj).Key;
                    }
           
           public override int GetHashCode()
             {
               int hash = 17;
               hash = hash * 23 + Key.GetHashCode();
               return hash;
             }
   
