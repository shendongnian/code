    using System;  
    using mynamespace.myFolder1;   
    
    namespace mynamespace.myFolder2  
    {  
       public class F2  
       {  
          // class properties...  
          // class methods...  
    
          // I have to access nested class F1_Nest here...  
          void F2_Method()  
          {
             F1.F1_Nest();  
          }
       }  
    }
