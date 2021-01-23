    namespace ElvisBugInNullableGenericStructWithNestedTypeParameter
    {
        struct MyGenericStruct<T> { }
        class Program
        {
            static void Main() { }
            void Test<T>()
            {
                Func<T, bool> func = (arg =>
                    {
                        MyGenericStruct<T>? v1 = null;
                        return v1?.ToString() == null;
                    });
            }
        }
    }
