    public class MyClass<TEnum> where TEnum: struct, IConvertible
    {        
        public int SomeMethod(TEnum value)
        {
            return value.ToInt32(null);
        }
    }
