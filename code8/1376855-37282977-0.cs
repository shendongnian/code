    class SubObject{
        public string Data;
    }
    class SubObjectA{
    }
    class SubObjectB{
    }
    class Test{
        T GetSubObject<T>() where T:SubObject,new()
        {
            return new T();
        }
    }
    
