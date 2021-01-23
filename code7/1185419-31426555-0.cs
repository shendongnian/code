                  public override bool Equals(Keyclass obj)
                    {
                      return this.Key == obj.Key;
                    }
           
           public override int GetHashCode()
             {
               int hash = 17;
               hash = hash * 23 + Key.GetHashCode();
               return hash;
             }
   
