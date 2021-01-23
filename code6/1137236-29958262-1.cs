    private static void Main(string[] args)
    {
      object instance = Activator.CreateInstance(typeof (XmlCodec<>).MakeGenericType(typeof (string)));
      // ISSUE: reference to a compiler-generated field
      if (Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site1 = CallSite<Action<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "ReadCollection", (IEnumerable<Type>) null, typeof (Program), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Action<CallSite, object, object> action = Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site1.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Action<CallSite, object, object>> callSite = Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site1;
      object obj1 = instance;
      // ISSUE: reference to a compiler-generated field
      if (Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site2 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetCollectionName", (IEnumerable<Type>) null, typeof (Program), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site2.Target((CallSite) Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site2, instance);
      action((CallSite) callSite, obj1, obj2);
      // ISSUE: reference to a compiler-generated field
      if (Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site3 = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Print", (IEnumerable<Type>) null, typeof (Program), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site3.Target((CallSite) Program.\u003CMain\u003Eo__SiteContainer0.\u003C\u003Ep__Site3, typeof (Program), instance);
      Console.ReadKey(true);
    }
