    //----------------------------------------------------------------------------------------------------------------
    // This is the one that actually loads the type once we've pinned down the Assembly it's in.
    //----------------------------------------------------------------------------------------------------------------
    /* private instance */ TypeHandle TypeName::GetTypeHaveAssembly(Assembly* pAssembly, BOOL bThrowIfNotFound, BOOL bIgnoreCase, BOOL bRecurse)
    for (COUNT_T i = 0; i < names.GetCount(); i ++)
    {
        LPCWSTR wname = names[i]->GetUnicode();
        MAKE_UTF8PTR_FROMWIDE(name, wname);
        typeName.SetName(name);       
        th = pAssembly->GetLoader()->LoadTypeHandleThrowing(&typeName);
    }
