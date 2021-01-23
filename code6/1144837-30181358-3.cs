    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace format_number
    {
	    class Program
	    {
		    static string FormatNumber(uint n)
		    {
			    if (n < 1000)
				    return n.ToString();
			
			    if (n < 1000000)
    			    return String.Format("{0:#,.##}K", n);
			    if (n < 1000000000)
    			    return String.Format("{0:#,,.##}M", n);
      			return String.Format("{0:#,,,.##}B", n);
	    	}
		static void Main(string[] args)
		{
			var s1 = FormatNumber(125);
			Console.Write(125 + "\t");
			Console.WriteLine(s1);
			var s2 = FormatNumber(1250);
			Console.Write(1250 + "\t");
			Console.WriteLine(s2);
			var s3 = FormatNumber(12500);
			Console.Write(12500 + "\t");
			Console.WriteLine(s3);
			var s4 = FormatNumber(125000);
			Console.Write(125000 + "\t");
			Console.WriteLine(s4);
			var s5 = FormatNumber(1250000);
			Console.Write(1250000 + "\t");
			Console.WriteLine(s5);
			var s6 = FormatNumber(12500000);
			Console.Write(12500000 + "\t");
			Console.WriteLine(s6);
			var s7 = FormatNumber(125000000);
			Console.Write(125000000 + "\t");
			Console.WriteLine(s7);
			var s8 = FormatNumber(999);
			Console.Write(999 + "\t");
			Console.WriteLine(s8);
			var s9 = FormatNumber(9999);
			Console.Write(9999 + "\t");
			Console.WriteLine(s9);
			var s10 = FormatNumber(99999);
			Console.Write(99999 + "\t");
			Console.WriteLine(s10);
			var s11 = FormatNumber(999999);
			Console.Write(999999 + "\t");
			Console.WriteLine(s11);
			var s12 = FormatNumber(9999999);
			Console.Write(9999999 + "\t");
			Console.WriteLine(s12);
			var s13 = FormatNumber(99999999);
			Console.Write(99999999 + "\t");
			Console.WriteLine(s13);
			var s14 = FormatNumber(999999999);
			Console.Write(999999999 + "\t");
			Console.WriteLine(s14);
			var s15 = FormatNumber(1999);
			Console.Write(1999 + "\t");
			Console.WriteLine(s15);
			var s16 = FormatNumber(1990);
			Console.Write(1990 + "\t");
			Console.WriteLine(s16);
			var s17 = FormatNumber(UInt32.MaxValue);
			Console.Write(UInt32.MaxValue + "\t");
			Console.WriteLine(s17);
		}
	}
    }
