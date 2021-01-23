    static class ParmPropClass<T>
    {
        private static List<CRcpParmPropEle<T, string>> ParmPropList;
        public static List<CRcpParmPropEle<T, string>> getParmPropList()
        {
            if (ParmPropList == null)
            {
                ParmPropList.Add(new CRcpParmPropEle<T, string>("Prop1", "BA", 0, false));
            }
            return ParmPropList;
        }
    }
