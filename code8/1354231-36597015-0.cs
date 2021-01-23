    using System;
    using System.Xml;
    using System.Text.RegularExpressions;
    
    namespace SOFAcrobatics
    {
        public static class Launcher
        {
            public static void Main ()
            {
                String xml = @"<VOUCHER>
        <REFERENCE TYPE=""String"">100</REFERENCE>
        <VNUMBER>568</VNUMBER>
    </VOUCHER>  
    <VOUCHER>
        <REFERENCE TYPE=""String"">100</REFERENCE>
        <VNUMBER>2</VNUMBER>
    </VOUCHER>";
                foreach (Match m in Regex.Matches(xml, @"<VNUMBER>(\d+)</VNUMBER>"))
                {
                    Console.WriteLine(m.Groups[1].Value);
                }
                Console.ReadKey(true);
            }
        }
    }
