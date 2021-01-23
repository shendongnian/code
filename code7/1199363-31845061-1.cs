    static byte[] AddArray(byte[] ary1, byte[] ary2) {
        System.Diagnostics.Debug.Assert(ary1.Length == ary2.Length);
        if ((ary1 == null) || (ary2 == null)) {
            throw new ArgumentException("Empty or null array");
        }
        // sum the last element
        var ix = ary1.Length - 1;
        var sum = (ary1[ix] + ary2[ix]);
        if (sum > byte.MaxValue) {
            if (ix == 0) {
                throw new ArgumentException("Overflow");
            }
            // Add carry by recursing on ary1
            var carry = (byte) (sum - byte.MaxValue);
            var carryAry = new byte[ary1.Length];
            carryAry[ix - 1] = carry;
            ary1 = AddArray(ary1, carryAry);
        }
            
        if ((ary1.Length == 1) || (ary2.Length == 1)) {
            return new byte[] { (byte) sum }; // end recursion
        }
        // create the remainder, elements from 0 it (len-1)
        var ary1Remainder = new byte[ary1.Length - 1];
        var ary2Remainder = new byte[ary2.Length - 1];
        Array.Copy(ary1, 0, ary1Remainder, 0, ary1.Length - 1);
        Array.Copy(ary2, 0, ary2Remainder, 0, ary2.Length - 1);
        // recurse
        var remainder = AddArray(ary1Remainder, ary2Remainder);
        // build return array (using linq Concat)
        var rv = (remainder.Concat(new byte[] { (byte) sum }));
        return rv.ToArray(); // return as an array 
    }
