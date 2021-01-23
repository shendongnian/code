          class MyClass 
          {
             int Id;
             String Name1;
             String Name2;
    
             public override string ToString()
             {
               return String.Format("{0} {1}", this.Name1, this.Name2);
             }
          }
