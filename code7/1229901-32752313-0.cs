    using System;
    
    class Hero
    {
        public Hero()
        {
            //code
        }  
    }
    
    class Fighter: Hero
    {
        private readonly int ignoreMe = BeforeBaseConstructorCall();
    
        public Fighter()
        {
        }
    
        private static int BeforeBaseConstructorCall()
        {
            //initailise the properties.
        }
    }
    
    class Test
    {
        static void Main()
        {
              //calls Fighter first & then Base()
              Fighter obj =  new Fighter();
        }    
    }
