    public static class Extensions
    {
        public static object CustomInvokeMember(this Type t, string name, BindingFlags invokeAttr, Binder binder,
            object target, object[] args)
        {
            try
            {
                return t.InvokeMember(name, invokeAttr, binder, target, args);
            }
            catch (Exception e)
            {
                //TODO: parsing, custom handling, etc
            }
            return null;
        }
    }
