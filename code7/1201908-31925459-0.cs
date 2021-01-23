<!-- language: lang-css --
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] input = new string[] {
                    "A.B.C.1.2.3.4.zip",
                    "A.B.C.1.2.3.5.zip",
                    "A.B.C.3.4.5.dll",
                    "A.B.C.1.2.3.6.zip",
                    "A.B.C.1.2.3.dll",
                    "X.Y.Z.7.8.9.0.zip",
                    "X.Y.Z.7.8.9.1.zip"
                };
                var parsed = input.Select(x => x.Split(new char[] {'.'}))
                    .Select(y => new {
                        name = string.Join(".", new string[] {y[0],y[1],y[2]}),
                        ext = y[y.Count() - 1],
                        major = int.Parse(y[3]),
                        minor = int.Parse(y[4]),
                        build = int.Parse(y[5]),
                        revision = y.Count() == 7 ? (int?)null : int.Parse(y[6])
                    }).ToList();
                var results = parsed.Where(x => (x.major >= 1) && (x.major <= 3)).ToList();
            }
        }
    }
    ​
