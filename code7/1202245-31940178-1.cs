    static void TestEnum<T>(T enumType) where T : struct
            {
                if (enumType is Enum1)
                {
                    Console.WriteLine("Enum1");
                }
                if (enumType is Enum2)
                {
                    Console.WriteLine("Enum2");
                }
            }
