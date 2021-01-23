    public static class program
    {
        static void Main(string[] args)
        {
            someClass testclass = new someClass();
            NullableEnumCopier<someClass, someEnum>.Copy(testclass);
        }
        public static class NullableEnumCopier<TClass, TEnum> where TEnum : struct
        {
            public static void Copy(TClass item)
            {
                PropertyInfo enumProperty = typeof(TClass).GetProperties()[0];
                Action<TClass, int> enumDelegate = CreateSetterFromPropertyInfo<TClass, int>(enumProperty);
                enumDelegate(item, 2);
                //Console.WriteLine(item.enumVal.ToString()); // writes B
                object nullableSetter = null;
                PropertyInfo enumPropertyNullable = typeof(TClass).GetProperties()[1];
                if (enumPropertyNullable.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (enumPropertyNullable.PropertyType.GetGenericArguments().First().IsEnum)
                    {
                        // the step below determines the method signature. I cannot deviate from what the property tells me.
                        // if I use int? instead of the PropertyType I get an ArgumentException.
                        MethodInfo method = typeof(program).GetMethod("CreateSetterFromPropertyInfo", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(new Type[] { typeof(TClass), enumPropertyNullable.PropertyType });
                        nullableSetter = method.Invoke(null, new object[] { enumPropertyNullable });
                    }
                }
                if (nullableSetter != null)
                {
                    Action<TClass, TEnum?> cast1 = (Action<TClass, TEnum?>) nullableSetter;
                    Action<TClass, Nullable<TEnum>> cast2 = (Action<TClass, Nullable<TEnum>>)nullableSetter;
                    // Action<TClass, Nullable<int>> cast3 = (Action<TClass, Nullable<int>>)nullableSetter;
                    // Action<TClass, Enum> cast4 = (Action<TClass, Enum>)nullableSetter;
                    // at this point I am trying to cast a string to a enum. That works. However the parameter should be a nullable enum.
                    Type subtype = enumPropertyNullable.PropertyType.GetGenericArguments().First();
                    Enum result = Enum.Parse(subtype, "B") as Enum;
                    // here is where I am getting the error. I can't find a way to cast the string I have to a nullable enum. 
                    cast1(item, (TEnum?)(object)result);
                }
            }
        }
        private static Action<C, P> CreateSetterFromPropertyInfo<C, P>(PropertyInfo property)
        {
            Action<C, P> setForAnyProperty = (Action<C, P>)Delegate.CreateDelegate(typeof(Action<C, P>), null, property.GetSetMethod());
            return setForAnyProperty;
        }
        public class someClass
        {
            public someEnum enumVal {get; set;}
            public someEnum? enumValNullable { get; set; }
        }
        public enum someEnum
        {
            A = 1,
            B = 2
        }
    }
