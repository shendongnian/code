    public RemarkStruct GetRemarkData<T>(T val)
    {
     if (typeof(T) == typeof(MyClass))
     {
        MyClass mc = (MyClass)(object) t;
     }
     else if (typeof(T) == typeof(List<MyClass>))
     {
        List<MyClass> lmc = (List<MyClass>)(object) t;
     }
    }
