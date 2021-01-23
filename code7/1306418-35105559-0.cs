    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            private const string Includes = "10-100, 200-300, 400-500 ";
            private const string Excludes = "95-205, 410-420";
            private const string Pattern = @"(\d*)-(\d*)";
    
            public static void Main(string[] args)
            {
                var includes = ParseIntevals(Includes);
                var excludes = ParseIntevals(Excludes);
    
                includes = ConcatinateIntervals(includes);
                excludes = ConcatinateIntervals(excludes);
                // The Result
                var result = ExcludeFromInclude(includes, excludes);
                foreach (var interval in result)
                {
                    Console.WriteLine(interval.Min + "-" + interval.Max);
                }            
            }
            
            /// <summary>
            /// Excludes intervals 'excludes' from 'includes'
            /// </summary>
            public static List<Interval> ExcludeFromInclude(List<Interval> includes, List<Interval> excludes)
            {
                var result = new List<Interval>();
                if (!excludes.Any())
                {
                    return includes.Select(x => x.Clone()).ToList();
                }
    
                for (int i = 0; i < includes.Count; i++)
                {
                    for (int j = 0; j < excludes.Count; j++)
                    {
                        if (includes[i].Max < excludes[j].Min || includes[i].Min > excludes[j].Max)
                            continue; // no crossing
    
                        //1 Example: includes[i]=(10-20) excludes[j]=(15-25)
                        if (includes[i].Min < excludes[j].Min && includes[i].Max <= excludes[j].Max)
                        {
                            var interval = new Interval(includes[i].Min, excludes[j].Min - 1);
                            result.Add(interval);
                            break;
                        }
                        //2 Example: includes[i]=(10-25) excludes[j]=(15-20)
                        if (includes[i].Min <= excludes[j].Min && includes[i].Max >= excludes[j].Max)
                        {
                            if (includes[i].Min < excludes[j].Min)
                            {
                                var interval1 = new Interval(includes[i].Min, excludes[j].Min - 1);
                                result.Add(interval1);
                            }
                            if (includes[i].Max > excludes[j].Max)
                            {
                                var interval2 = new Interval(excludes[j].Max + 1, includes[i].Max);
                                result.Add(interval2);
                            }
                            break;
                        }
                        //3 Example: includes[i]=(15-25) excludes[j]=(10-20)
                        if (includes[i].Min < excludes[j].Max && includes[i].Max > excludes[j].Max)
                        {
                            var interval = new Interval(excludes[j].Max + 1, includes[i].Max);
                            result.Add(interval);
                            break;
                        }
                    }
                }
                return result;
            }
            /// <summary>
            /// Concatinates intervals if they cross each over
            /// </summary>
            public static List<Interval> ConcatinateIntervals(List<Interval> intervals)
            {
                var result = new List<Interval>();
                for (int i = 0; i < intervals.Count; i++)
                {
                    for (int j = 0; j < intervals.Count; j++)
                    {
                        if (i == j)
                            continue;
                        if (intervals[i].Max < intervals[j].Min || intervals[i].Min > intervals[j].Max)
                        {
                            Interval interval = intervals[i].Clone();
                            result.Add(interval);
                            continue; // no crossing
                        }
                        //1
                        if (intervals[i].Min < intervals[j].Min && intervals[i].Max < intervals[j].Max)
                        {
                            var interval = new Interval(intervals[i].Min, intervals[j].Max);
                            result.Add(interval);
                            break;
                        }
    
                        //2
                        if (intervals[i].Min < intervals[j].Min && intervals[i].Max > intervals[j].Max)
                        {
                            Interval interval = intervals[i].Clone();
                            result.Add(interval);
                            break;
                        }
                        //3
                        if (intervals[i].Min < intervals[j].Max && intervals[i].Max > intervals[j].Max)
                        {
                           var interval = new Interval(intervals[j].Min, intervals[i].Max);
                            result.Add(interval);
                            break;
                        }
                        //4
                        if (intervals[i].Min > intervals[j].Min && intervals[i].Max < intervals[j].Max)
                        {
                            var interval = new Interval(intervals[j].Min, intervals[j].Max);
                            result.Add(interval);
                            break;
                        }
                    }
                }
    
                return result.Distinct().ToList();
            }
            /// <summary>
            /// Parses a source line of intervals to the list of objects
            /// </summary>
            public static List<Interval> ParseIntevals(string intervals)
            {
                var matches = Regex.Matches(intervals, Pattern, RegexOptions.IgnoreCase);
                var list = new List<Interval>();
                foreach (Match match in matches)
                {
                    var min = int.Parse(match.Groups[1].Value);
                    var max = int.Parse(match.Groups[2].Value);
                    list.Add(new Interval(min, max));
                }
                return list.OrderBy(x => x.Min).ToList();
            }
            /// <summary>
            /// Interval
            /// </summary>
            public class Interval
            {
                public int Min { get; set; }
                public int Max { get; set; }
                public Interval()
                {
                }
                public Interval(int min, int max)
                {
                    Min = min;
                    Max = max;
                }
                public override bool Equals(object obj)
                {
                    var obj2 = obj as Interval;
                    if (obj2 == null) return false;
                    return obj2.Min == Min && obj2.Max == Max;
                }
                public override int GetHashCode()
                {
                    return this.ToString().GetHashCode();
                }
                public override string ToString()
                {
                    return string.Format("{0}-{1}", Min, Max);
                }
                public Interval Clone()
                {
                    return (Interval) this.MemberwiseClone();
                }
            }
        }
    }
