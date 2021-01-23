    public class Factory
    {
        public Base<T> GetInstance<T>(int type)
        {
            if (type == 0)
                return (Base<T>)(object)new A();
            else
                return (Base<T>)(object)new B();
        }
    }
