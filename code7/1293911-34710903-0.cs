        public sealed class Blueprint 
        {
            public ComponentTable Components { get; set; }
    There doesn't appear to be any sort of configuration option to work around this.  From [`Reflection.cs`](https://github.com/mgholam/fastJSON/blob/master/fastJSON/Reflection.cs) you can see the method to create the setter delegate returns `null` if the setter is not public:
        internal static GenericSetter CreateSetMethod(Type type, PropertyInfo propertyInfo)
        {
            MethodInfo setMethod = propertyInfo.GetSetMethod();
            if (setMethod == null)
                return null;
