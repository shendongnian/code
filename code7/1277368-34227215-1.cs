    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                int[] values = {1, 2, 3, 5, 5, 5, 7, 8, 9};
                test(values,  5);
                test(values, -1);
                test(values, 10);
                test(values,  4);
                test(values,  6);
            }
            public static void test(int[] values, int target)
            {
                var range = EqualRange(values, target);
                Console.WriteLine($"Range for {target} is [{range.Item1}, {range.Item2})");
            }
            // If the range is not found
            public static Tuple<int, int> EqualRange<T>(IList<T> values, T target) where T : IComparable<T>
            {
                int lowerBound = LowerBound(values, target, 0, values.Count);
                int upperBound = UpperBound(values, target, lowerBound, values.Count);
                return new Tuple<int, int>(lowerBound, upperBound);
            }
            public static int LowerBound<T>(IList<T> values, T target, int first, int last) where T: IComparable<T>
            {
                int left  = first;
                int right = last;
                while (left < right)
                {
                    int mid = left + (right - left)/2;
                    var middle = values[mid];
                    if (middle.CompareTo(target) < 0)
                        left = mid + 1;
                    else
                        right = mid;
                }
                return left;
            }
            public static int UpperBound<T>(IList<T> values, T target, int first, int last) where T : IComparable<T>
            {
                int left  = first;
                int right = last;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    var middle = values[mid];
                    if (middle.CompareTo(target) > 0)
                        right = mid;
                    else
                        left = mid + 1;
                }
                return left;
            }
        }
    }
