    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string key =
                    "-----BEGIN RSA PRIVATE KEY-----\n" +
                    "MIICXQIDEMODEMODEMODEMODEMOEbGslt0N21onxRjBUwXFKI7CN6clxPAS+nEUK\n" +
                    "BZAEiJUDJLqcGa37EZv40UQnmGKpLZO3ypee9qvKRVC4Q3Oi3S+Ukfet7eJYvCwr\n" +
                    "WlneDOqvzyDz8cwlLcE2YhOnCMLYJ3v3YSt0n10oryaKyADDbCd5PmBbUwIEB7CO\n" +
                    "+QKBgCtLDEMODEMODEMODEMODEMOnNVbWYfVLhFJpdS1+5dTZbkOg6zaP+A/VKf1w\n" +
                    "3psFl7VfbggqiEvAi+4hTULVZu0W0wqPQUkw+rGzVT8Fg1uwBrzUKScJbscuRE/J\n" +
                    "1I6iizZ0sudjUynn+EORc12p1NRslf2BUW3nFIognt849r9JAkEA1V+5aGmJLZPP\n" +
                    "xZ/ETst7tb1WMeOvNxu+s/h2kcW6+WCvlUErYiB2/E/LkTbYGXu5/OHIMDgbQbB+\n" +
                    "28Bu7lYmUwJBAM12343234235AEIDmvGJChsPOaqwnClV/fSEx/6E8DXMhDHTENA\n" +
                    "STt+v4k1rlkSlM2aliZ8kz2u8K45SepsVwECQQCmECecqVtfuIvC+8EKvlM536OT\n" +
                    "XrLIeDOkRak8yRqQFEZzAlOXkOtKIxHBJuVT39sPK+xzU30FwRdLE858eBphAkB+\n" +
                    "LExh7ejTrxN3dHr1mDhJWoLzm59dzgwfmuEznnH+OmMZSAY21IouIAXjnKfXeCLo\n" +
                    "fRvUv5EuQkvGUJi1/25JAkAXZy7yjsJxaNBGB9TxakoHHnI2yWI/R9yewhzLorNo\n" +
                    "Oj49W6l9uaWaNxxmCrNZRIZoDEMODEMODEMODEMODEMO\n" +
                    "-----END RSA PRIVATE KEY-----\n";
                Regex expr = new Regex("-.*$", RegexOptions.Multiline);
                key = expr.Replace(key, "").Trim();
            }
        }
    }
    ​
