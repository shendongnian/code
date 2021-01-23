    public static List<CRcpParmPropEle<CParam1, string>> getParmPropList()
    {
        if (ParmPropList == null)
        {
            AddToList(ParmPropList, "Prop1", "BA", 0, false);
        }
        return ParmPropList;
    }
    private static void AddToList<T>(List<CRcpParmPropEle<T, string>> list, string s1, string s2, int i, bool f)
    {
        list.Add(new CRcpParmPropEle<T, string>(s1, s2, i, f));
    }
