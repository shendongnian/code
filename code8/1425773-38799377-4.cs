        interface IFoo
        {
            int Int { get; set; } 
        }
    
        class Foo : IFoo
        {
            public int Int { get; set; }
        }
    
        interface IDto<out T> where T : IFoo
        {
            T Obj { get; }
        }
    
        class Dto<T> : IDto<T> where T : IFoo
        {
            public T Obj { get; set; }
        }
