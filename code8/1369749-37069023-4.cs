    [System.Security.SecurityCritical]  // auto-generated
    private unsafe String CtorCharPtr(char *ptr)
    {
        if (ptr == null)
            return String.Empty;
    #if !FEATURE_PAL
        if (ptr < (char*)64000)
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeStringPtrNotAtom"));
    #endif // FEATURE_PAL
        Contract.Assert(this == null, "this == null");        // this is the string constructor, we allocate it
        try {
            int count = wcslen(ptr);
            if (count == 0)
                return String.Empty;
            String result = FastAllocateString(count);
            fixed (char *dest = result)
                wstrcpy(dest, ptr, count);
            return result;
        }
        catch (NullReferenceException) {
            throw new ArgumentOutOfRangeException("ptr", Environment.GetResourceString("ArgumentOutOfRange_PartialWCHAR"));
        }
    }
