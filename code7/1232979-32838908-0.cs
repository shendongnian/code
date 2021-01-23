    class Base<T>
    {
        protected T SomeField;
    }
    class Derived : Base<SomeType>
    {
        private Type GetSomeType(bool asConstructed)
        {
            // here SomeField is SomeType because Derived is a constructed type.
            if (asConstructed)
               return SomeField.GetType(); // of course, if SomeField is null, use GetField instead
            // However, you can get the T if you really want:
            return this.GetType().BaseType.GetGenericTypeDefinition().GetGenericArguments()[0];
        }
    }
