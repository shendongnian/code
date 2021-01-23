    // This is called via the following methods
    // 1.) Convert.ToInt32()
    // 2.) Int32.Parse()
    // 3.) Number.ParseInt32()
    // 4.) StringToNumber() (this method)
    [System.Security.SecuritySafeCritical]  // auto-generated
    private unsafe static void StringToNumber(String str, NumberStyles options, ref NumberBuffer number, NumberFormatInfo info, Boolean parseDecimal) {
    
            if (str == null) {
                throw new ArgumentNullException("String");
            }
            Contract.EndContractBlock();
            Contract.Assert(info != null, "");
            fixed (char* stringPointer = str) {
                char * p = stringPointer;
                if (!ParseNumber(ref p, options, ref number, null, info , parseDecimal) 
                    || (p - stringPointer < str.Length && !TrailingZeros(str, (int)(p - stringPointer)))) {
                    throw new FormatException(Environment.GetResourceString("Format_InvalidString"));
                }
            }
    }
        
    private static Boolean TrailingZeros(String s, Int32 index) {
            // For compatability, we need to allow trailing zeros at the end of a number string
            for (int i = index; i < s.Length; i++) {
                if (s[i] != '\0') {
                    return false;
                }
            }
            return true;
    }
