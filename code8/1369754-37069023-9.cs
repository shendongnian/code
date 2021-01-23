        [System.Security.SecuritySafeCritical]  // auto-generated
        private String CtorCharArray(char [] value)
        {
            if (value != null && value.Length != 0) {
                String result = FastAllocateString(value.Length);
 
                unsafe {
                    fixed (char * dest = result, source = value) {
                        wstrcpy(dest, source, value.Length);
                    }
                }
                return result;
            }
            else
                return String.Empty;
        }
