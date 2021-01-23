    >#r "C:\Users\...\Project.dll"
    >using System;
    >using System.Reflection;
    >Assembly assembly = >Assembly.LoadFrom("C:\Users\...\Project.dll");
    > Object mc = assembly.CreateInstance("AccessInternal.MyClass");
    > Type t = mc.GetType();
    > BindingFlags bf = BindingFlags.Instance | BindingFlags.NonPublic;
    > MethodInfo mi = t.GetMethod("MyMethod", bf);
    > string result = (string)mi.Invoke(mc, null);
    > Console.WriteLine(result);
    Hello world!
    >
 
