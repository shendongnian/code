        static void Main(string[] args)
        {
            //parse input strings, get borders of sub-intervals as Points
            //Inc=true means its from an including interval
            var inc = Regex.Matches("10-100, 200-300, 400-500", "[0-9]+").Cast<Match>().Select(s => int.Parse(s.Value)).Select(x => new Point(true, x));
            var exc = Regex.Matches("95-205, 410-420", "[0-9]+").Cast<Match>().Select(s => int.Parse(s.Value)).Select(x => new Point(false, x));
            //put all points in a line
            var rng = inc.Union(exc).OrderBy(x => x.Val).ToArray();
            int i = 0, e = 0;   //count interval/exterval border points passed
            int start = 0;  //start of the next resulting interval
            for (int n = 0; n < rng.Length; n++)
            {
                var p = rng[n];  //get next point
                if (p.Inc)  //this is a border of including interval
                {
                    if (i % 2 == 0 && e % 2 == 0)
                    {
                        start = p.Val;  //start new interval
                    }
                    else if (i % 2 == 1 && e % 2 == 0)
                    {
                        Console.WriteLine(start + ".." + p.Val);    //end interval
                    }
                    i++;
                }
                else
                {
                    if (i % 2 == 1 && e % 2 == 0)
                    {
                        Console.WriteLine(start + ".." + (p.Val - 1));    //chop interval
                    }
                    else if (i % 2 == 1 && e % 2 == 1)
                    {
                        start = p.Val + 1;  //start new interval
                    }
                    e++;
                }
            }
            Console.ReadLine();
        }
        public struct Point
        {
            public bool Inc;
            public int Val;
            public Point(bool kind, int val) {
                Inc = kind;
                Val = val;
            }
        }
