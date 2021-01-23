    // Decompiled with JetBrains decompiler
    // Type: Caliburn.Micro.BootstrapperBase
    // Assembly: Caliburn.Micro, Version=1.5.2.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f
    // MVID: DC6F950D-BBB2-4CAB-9754-D5C81FE2659F
    // Assembly location: ..\bin\Debug\Caliburn.Micro.dll
    if (Execute.InDesignMode)
      {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        Assembly assembly = Enumerable.LastOrDefault<Assembly>((IEnumerable<Assembly>) (currentDomain.GetType().GetMethod("GetAssemblies").Invoke((object) currentDomain, (object[]) null) as Assembly[] ?? new Assembly[0]), new Func<Assembly, bool>(BootstrapperBase.ContainsApplicationClass));
        if (assembly == (Assembly) null)
          return (IEnumerable<Assembly>) new Assembly[0];
        return (IEnumerable<Assembly>) new Assembly[1]
        {
          assembly
        };
      }
      else
      {
        Assembly entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly == (Assembly) null)
          return (IEnumerable<Assembly>) new Assembly[0];
        return (IEnumerable<Assembly>) new Assembly[1]
        {
          entryAssembly
        };
      }
