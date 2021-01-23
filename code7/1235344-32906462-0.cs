    public string Substring(int startIndex, int length)
    {
        if (startIndex < 0)
        {
            throw new ...
        }
        if (startIndex > this.Length)
        {
            throw new ...
        }
        if (length < 0)
        {
            throw new ...
        }
        if (startIndex > (this.Length - length))
        {
             throw new ...
        }
        if (length == 0) // <-- NOTICE HERE
        {
            return Empty;
        }
        if ((startIndex == 0) && (length == this.Length))
        {
            return this;
        }
        return this.InternalSubString(startIndex, length);
    }
