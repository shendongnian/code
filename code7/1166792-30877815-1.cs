    public class SecondDrawingPathCorrect<TFILE> : ValueResolver<FAG_DETAIL, string>
    where TFILE : FAG_DETAIL
    {
        private readonly string _replaceKey;
        public SecondDrawingPathCorrect(string replaceKey)
        {
            _replaceKey = replaceKey;
        }
    
        protected override string ResolveCore(FAG_DETAIL detail)
        {   
            string corrected = "";
            if (detail.TXT06.Length > 0)
            {                
                string inputdetail = detail.TXT06;
                corrected = inputdetail.Substring(inputdetail.IndexOf(_replaceKey) + 5, inputdetail.Length - inputdetail.IndexOf("_replaceKey) - 5);
            }
    
            return corrected;
        }
    }
