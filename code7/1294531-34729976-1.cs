    class SampleExpression
    {
        public string str;
    
        public static bool SampleEnum(SampleExpression s, IEnumerable<string> ien)
        {
            return ien.Contains(s.str);
        }
    }
    // Usage:
    var items = lst.Where(x => SampleExpression.SampleEnum(x, lstConstant))
        .ToList();
