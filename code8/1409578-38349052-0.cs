    namespace ElvisBugInNullableGenericStructWithNestedTypeParameter
    {
        struct MyGenericStruct<T> { }
        class Program
        {
            static void Main() { }
            void Test<T>()
            {
                Enumerable.Repeat(typeof(T), 1).Where(
                    i =>
                    {
                        return Enumerable.Empty<T>().FirstOrDefault(arg =>
                          {
                              MyGenericStruct<T>? v1 = null;
                              return v1?.ToString() == null;
                          }) != null;
                    });
            }
        }
    }
