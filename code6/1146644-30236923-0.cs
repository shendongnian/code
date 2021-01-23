    public class CustomComparer : IComparer<string> {
      Comparer _comparer = new Comparer(System.Globalization.CultureInfo.CurrentCulture);
      public int Compare(string x, string y) {
         string numxs = string.Concat(x.TakeWhile(c => char.IsDigit(c)).ToArray());
         string numys = string.Concat(y.TakeWhile(c => char.IsDigit(c)).ToArray());
         int xnum;
         int ynum;
         if (!int.TryParse(numxs, out xnum) || !int.TryParse(numys, out ynum)) {
            return _comparer.Compare(x, y);
         }
         int compareNums = xnum.CompareTo(ynum);
         if (compareNums != 0) {
            return compareNums;
         }
         return _comparer.Compare(x, y);
      }
    }
