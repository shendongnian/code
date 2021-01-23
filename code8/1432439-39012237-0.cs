    public class AlphaNumericSorter : IComparer<string>
    {
        public int Compare(string x, string y)
        {
    		return SafeNativeMethods.StrCmpLogicalW(x, y);
        }
    }
    
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        public static extern int StrCmpLogicalW(string psz1, string psz2);
    }
