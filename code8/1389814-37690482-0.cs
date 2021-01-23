    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    
    public static class Sample1
    {
    	public static void Main()
    	{
    		var sampleInput = "XX,VV,A01,A02,A03,A11,A12,A13,A14,B11,B12,B13,ZZ,DD";
    		var results = Regex.Replace(sampleInput, "A0[2-9]|A1[0-5]", "AA");
    		Console.WriteLine("Line: {0}", results);
    	}
    }
