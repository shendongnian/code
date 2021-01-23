    private static void ShowTypeInfo(Type t)
    {
       Console.WriteLine("Name: {0}", t.Name);
       Console.WriteLine("Full Name: {0}", t.FullName);
       Console.WriteLine("ToString:  {0}", t.ToString());
       Console.WriteLine("Assembly Qualified Name: {0}",
                           t.AssemblyQualifiedName);
       Console.WriteLine();
    }
