    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Test
    {
        using Pair = Tuple<int, int>;   //for brevity
    
        struct Point    //point of an interval
        {
            public enum Border { Left, Right };
            public enum Interval { Including, Excluding };
            public int Val;
            public int Brdr;
            public int Intr;
            public Point(int value, Border border, Interval interval)
            {
                Val = value;
                Brdr = (border == Border.Left) ? 1 : -1;
                Intr = (int)interval;
            }
            public override string ToString() =>
                (Brdr == 1 ? "L" : "R") + (Intr == 0 ? "+ " : "- ") + Val;
        }
    
        class Program
        {
            static IEnumerable<Pair> GetInterval(string strIn, string strEx)
            {
                //a func to get interval border points from string:
                Func<string, Point.Interval, IEnumerable<Point>> parse = (str, intr) =>
                   Regex.Matches(str, "[0-9]+").Cast<Match>().Select((s, idx) =>
                   new Point(int.Parse(s.Value), (Point.Border)(idx % 2), intr));
    
                var INs = parse(strIn, Point.Interval.Including);
                var EXs = parse(strEx, Point.Interval.Excluding);
    
                var intrs = new int[2];  //current interval border control IN[0], EX[1]
                int start = 0;       //left border of a new resulting interval
                //put all points in a line and loop:
                foreach (var p in INs.Union(EXs).OrderBy(x => x.Val))
                {
                    //check for start (close) of a new (cur) interval:
                    var change = (intrs[p.Intr] == 0) ^ (intrs[p.Intr] + p.Brdr == 0);
                    intrs[p.Intr] += p.Brdr;
                    if (!change) continue;
    
                    var In = p.Intr == 0 && intrs[1] == 0;  //w no Ex
                    var Ex = p.Intr == 1 && intrs[0] > 0;   //breaks In
                    var Open = intrs[p.Intr] > 0;
                    var Close = !Open;
    
                    if (In && Open || Ex && Close)
                    {
                        start = p.Val + p.Intr; //exclude point if Ex
                    }
                    else if (In && Close || Ex && Open)
                    {
                        yield return new Pair(start, p.Val - p.Intr);
                    }
                }
            }
    
            static void Main(string[] args)
            {
                var strIN = "10-100, 200-300, 400-500, 420-480";
                var strEX = "95-205, 410-420";
    
                foreach (var i in GetInterval(strIN, strEX))
                    Console.WriteLine(i.Item1 + "-" + i.Item2);
    
                Console.ReadLine();
            }
        }
    }
