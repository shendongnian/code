     /// <summary>
     /// Casts two unsigned integers to signed integers
     /// and compares them
     /// </summary>
     /// <param name="arg1">Left side of inequality</param>
     /// <param name="arg2">Right side of inequality</param>
     /// <returns><para>
     /// LESS_THAN iff <paramref name="arg1"/>
     /// &lt; <paramref name="arg2"/>
     /// </para><para>
     /// GREATER_THAN iff <paramref name="arg1"/>
     /// &gt; <paramref name="arg2"/>
     /// </para><para>
     /// EQUAL_TO iff <paramref name="arg1"/>
     /// == <paramref name="arg2"/>
     /// </para></returns>
     private static Inequality Compare(
           uint arg1, uint arg2)
     {
       var int1 = (int)arg1;
       var int2 = (int)arg2;
       return int1 < int2
         ? Inequality.LESS_THAN
           : int1 > int2
           ? Inequality.GREATER_THAN
             : Inequality.EQUAL_TO;
     }  // end: Compare()
