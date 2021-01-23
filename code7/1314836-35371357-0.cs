            [Pure]
            public bool Contains( string value ) {
                 return ( IndexOf(value, StringComparison.Ordinal) >=0 );
            }
    
            [Pure]
            public int IndexOf(String value, StringComparison comparisonType) {
                return IndexOf(value, 0, this.Length, comparisonType);
            }
            [Pure]
            [System.Security.SecuritySafeCritical]
            public int IndexOf(String value, int startIndex, int count, StringComparison comparisonType) {
                // Validate inputs
                if (value == null)
                    throw new ArgumentNullException("value");
     
                if (startIndex < 0 || startIndex > this.Length)
                    throw new ArgumentOutOfRangeException("startIndex", Environment.GetResourceString("ArgumentOutOfRange_Index"));
     
                if (count < 0 || startIndex > this.Length - count)
                    throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_Count"));
                Contract.EndContractBlock();
     
                switch (comparisonType) {
                    case StringComparison.CurrentCulture:
                        return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.None);
     
                    case StringComparison.CurrentCultureIgnoreCase:
                        return CultureInfo.CurrentCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
     
                    case StringComparison.InvariantCulture:
                        return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.None);
     
                    case StringComparison.InvariantCultureIgnoreCase:
                        return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
     
                    case StringComparison.Ordinal:
                        return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.Ordinal);
     
                    case StringComparison.OrdinalIgnoreCase:
                        if (value.IsAscii() && this.IsAscii())
                            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(this, value, startIndex, count, CompareOptions.IgnoreCase);
                        else
                            return TextInfo.IndexOfStringOrdinalIgnoreCase(this, value, startIndex, count);
     
                    default:
                        throw new ArgumentException(Environment.GetResourceString("NotSupported_StringComparison"), "comparisonType");
                }  
            }
