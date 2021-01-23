    // Determines whether two strings match.
    [Pure]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public bool Equals(String value) {
        if (this == null)                        //this is necessary to guard against reverse-pinvokes and
            throw new NullReferenceException();  //other callers who do not use the callvirt instruction
 
        if (value == null)
            return false;
        if (Object.ReferenceEquals(this, value))
            return true;
        
        if (this.Length != value.Length)
            return false;
 
        return EqualsHelper(this, value);
    }
