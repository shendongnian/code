    interface IService<in T>
    {
        void ApplyChanges(T param);
    }
    
    class Param1
    {
        public int X { get; set; }
    }
    class Service1 : IService<Param1>
    {
        public void ApplyChanges(Param1 param)
        {
            param.X = 123;
        }
    }
    
    class Param2
    {
        public int Y { get; set; }
    }
    class Service2 : IService<Param2>
    {
        public void ApplyChanges(Param2 param)
        {
            param.Y = 456;
        }
    }
