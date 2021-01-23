    public class MsAccess
    {
        private Microsoft.Office.Interop.Access._Application _oAccess;
        public MsAccess(string path)
        {
            _oAccess = (Microsoft.Office.Interop.Access._Application)System.Runtime.InteropServices.Marshal.BindToMoniker(path);
        }
        public string ReturnSqlQueryText(string queryName)
        {
            string queryDef = null;
            var qdefs = _oAccess.CurrentDb().QueryDefs;
            foreach (QueryDef qdef in qdefs)
            {
                if(qdef.Name.Equals(queryName))
                    queryDef = qdef.SQL;
            }
            return queryDef;
        }
    }
