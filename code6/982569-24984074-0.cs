    using System.Reflection;
    Type t = Type.GetType("yourNamespace.Form" + numericUpDown1.Text);
    if (t!=null)
    {
        object instance = Activator.CreateInstance(t);
        MethodInfo mI = t.GetMethod("Show", new Type[0]);
        mI.Invoke(instance, null);
    }
