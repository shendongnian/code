     public class SomeClass
     {
         private Action mySavedFunction;
    
         private int  DoInt () { return 1;}
         private void Do    () { }
    
         public int value { get; set { mySavedFunction(); } }
    
         public SomeClass ( bool b)
         {
            if (b)
              mySavedFunction = () => this.DoInt();
            else 
              mySavedFunction = this.Do;
         }      
     }
