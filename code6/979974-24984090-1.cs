    private static void MyFoo([Dynamic] object dyn)
    {
        object obj2;
        CSharpArgumentInfo[] infoArray;
        bool flag;
        if (<MyFoo>o__SiteContainer0.<>p__Site1 != null)
        {
            goto Label_0038;
        }
        <MyFoo>o__SiteContainer0.<>p__Site1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(0, 0x53, typeof(Program), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(0, null) }));
    Label_0038:
        if (<MyFoo>o__SiteContainer0.<>p__Site2 != null)
        {
            goto Label_0088;
        }
        <MyFoo>o__SiteContainer0.<>p__Site2 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(0, 13, typeof(Program), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(0, null), CSharpArgumentInfo.Create(2, null) }));
    Label_0088:
        if ((<MyFoo>o__SiteContainer0.<>p__Site1.Target(<MyFoo>o__SiteContainer0.<>p__Site1, <MyFoo>o__SiteContainer0.<>p__Site2.Target(<MyFoo>o__SiteContainer0.<>p__Site2, dyn, null)) == 0) == null)
        {
            goto Label_00AE;
        }
        obj2 = dyn;
    Label_00AE:
        return;
    }
