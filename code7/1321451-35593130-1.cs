        private static object InitDefaultValue(Type MemberType)
        {
            if (MemberType.IsValueType)
                return MemberType.InvokeMember(string.Empty, BindingFlags.CreateInstance, null, null, new object[0]);
            else
                return null;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(InitDefaultValue(typeof(System.Int32)));
        }
