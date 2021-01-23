    using System;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    
    namespace SOFAcrobatics
    {
        public static class Launcher
        {
            public static void Main ()
            {
                Console.WriteLine(Launcher.IPv4ToQuadNotation(new IPAddress(4294967295)));
                // outputs 255.255.255.255
                Console.ReadKey(true);
            }
    
            public static String IPv4ToQuadNotation (IPAddress ip)
            {
                String output = String.Empty;
                foreach (Match m in Regex.Matches(ip.Address.ToString("X8"), @"[A-F0-9]{2}"))
                {
                    output += (Int32.Parse(m.Value, NumberStyles.HexNumber) + ".");
                }
                return output.Substring(0, (output.Length - 1));
            }
        }
    }
