    public static class program
    {
        static void Main(string[] args)
        {
            someClass testclass = new someClass();
            PropertyInfo enumProperty = typeof(someClass).GetProperties()[0];
            Action<someClass, int> enumDelegate = CreateSetterFromPropertyInfo<someClass, int>(enumProperty);
            enumDelegate(testclass, 2);
            Console.WriteLine(testclass.enumVal.ToString()); // writes B
            object nullableSetter = null;
            PropertyInfo enumPropertyNullable = typeof(someClass).GetProperties()[1];
            if (enumPropertyNullable.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (enumPropertyNullable.PropertyType.GetGenericArguments().First().IsEnum)
                {
                    // the step below determines the method signature. I cannot deviate from what the property tells me.
                    // if I use int? instead of the PropertyType I get an ArgumentException.
                    MethodInfo method = typeof(program).GetMethod("CreateSetterFromPropertyInfo", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(new Type[] { typeof(someClass), enumPropertyNullable.PropertyType });
                    nullableSetter = method.Invoke(null, new object[] { enumPropertyNullable });
                }
            }
            if (nullableSetter != null)
            {
                Action<someClass, someEnum?> cast1 = (Action<someClass, someEnum?>) nullableSetter;
                Action<someClass, Nullable<someEnum>> cast2 = (Action<someClass, Nullable<someEnum>>)nullableSetter;
                // Action<someClass, Nullable<int>> cast3 = (Action<someClass, Nullable<int>>)nullableSetter;
                // Action<someClass, Enum> cast4 = (Action<someClass, Enum>)nullableSetter;
                // at this point I am trying to cast a string to a enum. That works. However the parameter should be a nullable enum.
                Type subtype = enumPropertyNullable.PropertyType.GetGenericArguments().First();
                Enum result = Enum.Parse(subtype, "B") as Enum;
                // here is where I am getting the error. I can't find a way to cast the string I have to a nullable enum. 
                cast1(testclass, (someEnum?)result);
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
