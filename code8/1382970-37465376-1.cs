    using System;  
    using mynamespace.myFolder1;   
    namespace mynamespace.myFolder2  
    {  
        public class F2  
        {  
            // class properties...  
            // class methods...  
    
            void SomeMethod()
            {
                // no need to instantiate an object of F1 class
                var f1Nest = new F1.F1_Nest();
            }  
        }  
    }
