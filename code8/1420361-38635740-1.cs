    interface ImanInterfaceWithA {
         int a {get; set;}
    }
    class foo { 
        struct A : ImanInterfaceWithA { 
           public int a {get; set;}
           public int b {get; set;}
        }
    
        struct B : ImanInterfaceWithA {
           public int a {get; set;}
           public int b {get; set;}
        } 
    
        
        void bar<T> (T input) where T : IamanInterfaceWithA
        {
            var a = input.a;
        }
    }
