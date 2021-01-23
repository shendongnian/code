    object boxed = p;
    PropertyInfo temp = p.GetType().GetProperty("X");
    temp.SetValue(boxed, 100, null);
    Console.WriteLine(boxed); // {X=100, Y=0}
    MethodInfo tt = temp.GetSetMethod();
    tt.Invoke(boxed, new object[] { 200 });
    Console.WriteLine(boxed); // {X=200, Y=0}
