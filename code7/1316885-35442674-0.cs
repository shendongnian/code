    private void Validate<C>() where C : class
    {
        Validate(typeof(C));
    } 
    private void Validate(Type type)
    {
        MemberInfo[] x = type.GetMembers();
        for (int i = 0; i < x.Length; i++)
        {
            if (x[i].MemberType != MemberTypes.Field && x[i].MemberType != MemberTypes.NestedType)
            {
                throw new Exception(string.Format("Class members must be of type Field or NestedType"));
            }
            foreach (var n in x.Where(a => a.MemberType == MemberTypes.NestedType))
                Validate(n);
        }
    }
