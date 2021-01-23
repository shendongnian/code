    await Runner(() => DoSomethingAsync("no await"));
        IL_001a: ldarg.0      // this
        IL_001b: ldfld        class WebCard.Controllers.CompanyManagementController WebCard.Controllers.CompanyManagementController/'<RunTheDemo>d__5'::'<>4__this'
        IL_0020: ldarg.0      // this
        IL_0021: ldfld        class WebCard.Controllers.CompanyManagementController WebCard.Controllers.CompanyManagementController/'<RunTheDemo>d__5'::'<>4__this'
        IL_0026: ldftn        instance class [mscorlib]System.Threading.Tasks.Task WebCard.Controllers.CompanyManagementController::'<RunTheDemo>b__5_0'()
        IL_002c: newobj       instance void class [mscorlib]System.Func`1<class [mscorlib]System.Threading.Tasks.Task>::.ctor(object, native int)
        IL_0031: callvirt     instance class [mscorlib]System.Threading.Tasks.Task WebCard.Controllers.CompanyManagementController::Runner(class [mscorlib]System.Func`1<class [mscorlib]System.Threading.Tasks.Task>)
        IL_0036: callvirt     instance valuetype [mscorlib]System.Runtime.CompilerServices.TaskAwaiter [mscorlib]System.Threading.Tasks.Task::GetAwaiter()
        IL_003b: stloc.1      // V_1
    await Runner(async () => await DoSomethingAsync("with await"));
        IL_0098: ldarg.0      // this
        IL_0099: ldfld        class WebCard.Controllers.CompanyManagementController WebCard.Controllers.CompanyManagementController/'<RunTheDemo>d__5'::'<>4__this'
        IL_009e: ldarg.0      // this
        IL_009f: ldfld        class WebCard.Controllers.CompanyManagementController WebCard.Controllers.CompanyManagementController/'<RunTheDemo>d__5'::'<>4__this'
        IL_00a4: ldftn        instance class [mscorlib]System.Threading.Tasks.Task WebCard.Controllers.CompanyManagementController::'<RunTheDemo>b__5_1'()
        IL_00aa: newobj       instance void class [mscorlib]System.Func`1<class [mscorlib]System.Threading.Tasks.Task>::.ctor(object, native int)
        IL_00af: callvirt     instance class [mscorlib]System.Threading.Tasks.Task WebCard.Controllers.CompanyManagementController::Runner(class [mscorlib]System.Func`1<class [mscorlib]System.Threading.Tasks.Task>)
        IL_00b4: callvirt     instance valuetype [mscorlib]System.Runtime.CompilerServices.TaskAwaiter [mscorlib]System.Threading.Tasks.Task::GetAwaiter()
        IL_00b9: stloc.3      // V_3
