    List<string> lstStr = GetListString(); // Get it somehow
    List<decimal> decs = lstStr.Select(str =>
    {
       decimal item = 0m;
       return new 
       {
         IsParsed =  decimal.TryParse(str, out item),
         Value = item
       };
    }).Where(o => o.IsParsed).Select(o => o.Value).ToList();
