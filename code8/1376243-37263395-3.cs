    EnumBuilder.GetFields(BindingFlags bindingAttr);
    TypeBuilder.GetFields(BindingFlags bindingAttr);
    RuntimeType.GetFields(BindingFlags bindingAttr);
    RuntimeType.GetFieldCandidates(String name, BindingFlags bindingAttr, bool allowPrefixLookup);
    RuntimeTypeCache.GetFieldList(MemberListType listType, string name);
    RuntimeTypeCache.GetMemberList<RuntimeFieldInfo>(ref MemberInfoCache<T> m_cache, MemberListType listType, string name, CacheType cacheType);
    MemberInfoCache<RuntimeFieldInfo>.GetMemberList(MemberListType listType, string name, CacheType cacheType);
    MemberInfoCache<RuntimeFieldInfo>.Populate(string name, MemberListType listType, CacheType cacheType);
    MemberInfoCache<RuntimeFieldInfo>.GetListByName(char* pName, int cNameLen, byte* pUtf8Name, int cUtf8Name, MemberListType listType, CacheType cacheType);
    MemberInfoCache<RuntimeFieldInfo>.PopulateFields(Filter filter);
    // and from here, it is a wild ride...
    
