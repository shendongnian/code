    class SampleExpression
    {
        public string str;
    
        public static Func<SampleExpression, bool> SampleEnum(IEnumerable<string> ien)
        {
            return s => ien.Contains(s.str);
        }
    }
    // Usage:
    var items = lst.Where(SampleExpression.SampleEnum(lstConstant))
        .ToList();
