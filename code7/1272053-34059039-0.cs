    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public sealed class InAttribute : Attribute
    {
        internal static Attribute GetCustomAttribute(RuntimeParameterInfo parameter)
        {
            return parameter.IsIn ? new InAttribute() : null;
        }
        internal static bool IsDefined(RuntimeParameterInfo parameter)
        {
            return parameter.IsIn;
        }
 
        public InAttribute()
        {
        }
    }
 
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    [System.Runtime.InteropServices.ComVisible(true)]
    public sealed class OutAttribute : Attribute
    {
        internal static Attribute GetCustomAttribute(RuntimeParameterInfo parameter)
        {
            return parameter.IsOut ? new OutAttribute() : null;
        }
        internal static bool IsDefined(RuntimeParameterInfo parameter)
        {
            return parameter.IsOut;
        }
 
        public OutAttribute()
        {
        }
    }
