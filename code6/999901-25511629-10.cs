    using FluentValidation;
    using Foos;
    using Performance;
    using ProfileScenarios;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Tests;
    namespace OptimizeValidation
    {
        class Program
        {
            // Constants
            const int WARM_UP_CALLS = 10;
            const int ITERATIONS = 100000;
            const int COUNT = 360;
            // Static for Debug
            static StringBuilder sb = new StringBuilder();
            // Main Entry Point
            static void Main(string[] args)
            {
                double Radius = 123.4;
                Console.WriteLine("WARM_UP_CALLS = {0}", WARM_UP_CALLS);
                Console.WriteLine("ITERATIONS = {0}", ITERATIONS);
                Console.WriteLine("COUNT = {0}", COUNT);
                Console.WriteLine("Radius = {0}", Radius);
                try
                {
                    // Inline Test Cases
                    Basic_Inline_Tests.FooObject_created_with_p_radius_of_negative_1_should_throw_ArgumentOutOfRangeException();
                    Basic_Inline_Tests.FooObject_created_with_p_radius_of_negative_1_in_unchecked_mode_should_not_throw();
                }
                catch (Exception ex)
                {
                    sb.AppendFormat("Unexpected Exception: {0}\r\n", ex.Message);
                }
                do
                {
                    Profiler
                        .Benchmark(
                            p_methodName: "Profile_Case_1_FooObject_With_Constructor_Validated",
                            p_warmUpCalls: WARM_UP_CALLS,
                            p_iterations: ITERATIONS,
                            p_action: () =>
                                {
                                    List<IFooObject> ListOfFoos = ProfileCases.Profile_Case_1_FooObject_With_Constructor_Validated(Radius, COUNT);
                                    ListOfFoos.Clear();
                                });
                    //Profiler - Won't compile with code updates
                    //    .Benchmark(
                    //        p_methodName: "Profile_Case_2_FooObject_Without_Constructor_Validation",
                    //        p_warmUpCalls: WARM_UP_CALLS,
                    //        p_iterations: ITERATIONS,
                    //        p_action: () =>
                    //            {
                    //                List<IFooObject> ListOfFoos = ProfileCases.Profile_Case_2_FooObject_Without_Constructor_Validation(Radius, COUNT);
                    //                ListOfFoos.Clear();
                    //            });
                    Profiler
                        .Benchmark(
                            p_methodName: "Profile_Case_3_UnSafeFooObject_ConstructorAssignment",
                            p_warmUpCalls: WARM_UP_CALLS,
                            p_iterations: ITERATIONS,
                            p_action: () =>
                            {
                                List<IFooObject> ListOfFoos = ProfileCases.Profile_Case_3_UnSafeFooObject_ConstructorAssignment(Radius, COUNT);
                                ListOfFoos.Clear();
                            });
                    Profiler
                        .Benchmark(
                            p_methodName: "Profile_Case_4_UnSafeFooObject_PublicFieldAssignment",
                            p_warmUpCalls: WARM_UP_CALLS,
                            p_iterations: ITERATIONS,
                            p_action: () =>
                            {
                                List<IFooObject> ListOfFoos = ProfileCases.Profile_Case_4_UnSafeFooObject_PublicFieldAssignment(Radius, COUNT);
                                ListOfFoos.Clear();
                            });
                    Profiler
                        .Benchmark(
                            p_methodName: "Profile_Case_5_FooObject_With_UnSafeOverload",
                            p_warmUpCalls: WARM_UP_CALLS,
                            p_iterations: ITERATIONS,
                            p_action: () =>
                            {
                                List<IFooObject> ListOfFoos = ProfileCases.Profile_Case_5_FooObject_With_UnSafeOverload(Radius, COUNT);
                                ListOfFoos.Clear();
                            });
                    sb
                        .AppendFormat(
                            "\r\n~~~~~~~~~~~~~~~~~\r\nRanked Results\r\n~~~~~~~~~~~~~~~~~\r\n{0}",
                            Profiler.Ranked_Results(p_descending: false));
                    Console.WriteLine(sb.ToString());
                    Console.WriteLine("Press Escape to exit, or any other key to run again.");
                    // Reset
                    Profiler.Clear();
                    sb.Clear();
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
        }
    }
    namespace FluentValidation
    {
        public class ValidateOverload
        { }
        public static class Validate
        {
            // Static Fields
            //private static bool m_disabled;
            public static ValidateOverload UnSafeOverload = new ValidateOverload();
            /// <summary>
            /// Validates the passed in parameter is above a specified limit, throwing a detailed exception message if the test fails.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="p_parameter">Parameter to validate.</param>
            /// <param name="p_limit">Limit to test parameter against.</param>
            /// <param name="p_name">Name of tested parameter to assist with debugging.</param>
            /// <param name="p_variableValueName">Name of limit variable, if limit is not hard-coded.</param>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static void MustBeAbove<T>(this IComparable<T> p_parameter, T p_limit, string p_name, string p_variableValueName = default(string))
                where T : struct
            {
                //// Naive approach
                //if (m_disabled)
                //    return;
                if (p_parameter.CompareTo(p_limit) <= 0)
                    if (p_variableValueName != default(string))
                        throw
                            new
                                ArgumentOutOfRangeException(string.Format(
                                "Parameter must be greater than the value of \"{0}\" which was {1}, but \"{2}\" was {3}.",
                                p_variableValueName, p_limit, p_name, p_parameter), default(Exception));
                    else
                        throw
                            new
                                ArgumentOutOfRangeException(string.Format(
                                "Parameter must be greater than {0}, but \"{1}\" was {2}.",
                                p_limit, p_name, p_parameter), default(Exception));
            }
            //// Some Class to control whether validation actually happens
            //public class BarContext : IDisposable
            //{
            //    // What goes here to get the current Thread|Task so that a flag
            //    // can indicate that validation was performed at a higher level
            //    // and doesn't need to be repeated?
            //    public BarContext()
            //    {
            //        // Naive approach
            //        m_disabled = true;
            //    }
            //    // Dispose
            //    public void Dispose()
            //    {
            //        // Naive approach
            //        m_disabled = false;
            //    }
            //}
            //// Some method to return a thread specific context object
            //public static IDisposable UncheckedContext()
            //{
            //    // What goes here?
            //    return
            //        new BarContext();
            //}
        }
    }
    namespace ProfileScenarios
    {
        public static class ProfileCases
        {
            // Profile Scenarios
            public static List<IFooObject> Profile_Case_1_FooObject_With_Constructor_Validated(double p_radius, int p_count)
            {
                // Validate
                p_radius
                    .MustBeAbove(0, "p_radius");
                p_count
                    .MustBeAbove(0, "p_count");
                var FooList = new List<IFooObject>(p_count);
                for (int i = 0; i < p_count; i++)
                    FooList.Add(new FooObject(p_radius, i));
                return
                    FooList;
            }
            //public static List<IFooObject> Profile_Case_2_FooObject_Without_Constructor_Validation(double p_radius, int p_count)
            //{
            //    // Validate
            //    p_radius
            //        .MustBeAbove(0, "p_radius");
            //    p_count
            //        .MustBeAbove(0, "p_count");
            //    var FooList = new List<IFooObject>(p_count);
            //    using (var UncheckedMode = Validate.UncheckedContext())
            //    {
            //        for (int i = 0; i < p_count; i++)
            //            FooList.Add(new FooObject(p_radius, i));
            //    }
            //    return
            //        FooList;
            //}
            public static List<IFooObject> Profile_Case_3_UnSafeFooObject_ConstructorAssignment(double p_radius, int p_count)
            {
                // Validate
                p_radius
                    .MustBeAbove(0, "p_radius");
                p_count
                    .MustBeAbove(0, "p_count");
                var FooList = new List<IFooObject>(p_count);
                for (int i = 0; i < p_count; i++)
                    FooList.Add(new UnSafeFooObject_ConstructorAssignment(p_radius, i));
                return
                    FooList;
            }
            public static List<IFooObject> Profile_Case_4_UnSafeFooObject_PublicFieldAssignment(double p_radius, int p_count)
            {
                // Validate
                p_radius
                    .MustBeAbove(0, "p_radius");
                p_count
                    .MustBeAbove(0, "p_count");
                var FooList = new List<IFooObject>(p_count);
                for (int i = 0; i < p_count; i++)
                {
                    var Foo = new UnSafeFooObject_PublicFieldAssignment();
                    Foo.Radius = p_radius;
                    Foo.Angle = i;
                    FooList.Add(Foo);
                }
                return
                    FooList;
            }
            public static List<IFooObject> Profile_Case_5_FooObject_With_UnSafeOverload(double p_radius, int p_count)
            {
                // Validate
                p_radius
                    .MustBeAbove(0, "p_radius");
                p_count
                    .MustBeAbove(0, "p_count");
                var FooList = new List<IFooObject>(p_count);
                for (int i = 0; i < p_count; i++)
                    FooList.Add(new FooObject(p_radius, i, Validate.UnSafeOverload));
                return
                    FooList;
            }
        }
    }
    namespace Tests
    {
        public static class Basic_Inline_Tests
        {
            public static void FooObject_created_with_p_radius_of_negative_1_should_throw_ArgumentOutOfRangeException()
            {
                try
                {
                    // Test
                    new FooObject(-1, 123);
                    // Test Failed
                    throw
                        new InvalidOperationException(
                            "FooObject created with p_radius of -1 should throw ArgumentOutOfRangeException.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Test Passed
                    Console.WriteLine("Test Passed");
                }
            }
            public static void FooObject_created_with_p_radius_of_negative_1_in_unchecked_mode_should_not_throw()
            {
                try
                {
                    // Test
                    new FooObject(-1, 123, Validate.UnSafeOverload);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    // Test Failed
                    throw
                        new InvalidOperationException(
                            "FooObject created in Unchecked Mode threw an exception.", ex);
                }
                // Test Passed
                Console.WriteLine("Test Passed");
            }
        }
    }
    namespace Foos
    {
        public interface IFooObject
        {
            /*Placeholder*/
        }
        public class FooObject : IFooObject
        {
            // Fields
            private double m_radius;
            private double m_angle;
            // Properties
            public double Radius { get { return m_radius; } }
            public double Angle { get { return m_angle; } }
            // Constructor
            public FooObject(double p_radius, double p_angle)
            {
                // Validate
                p_radius
                    .MustBeAbove(0, "p_radius");
                // Init
                m_radius = p_radius;
                m_angle = p_angle;
            }
            public FooObject(double p_radius, double p_angle, ValidateOverload p_uncheckedMode)
            {
                // Init
                m_radius = p_radius;
                m_angle = p_angle;
            }
        }
        public class UnSafeFooObject_ConstructorAssignment : IFooObject
        {
            // Fields
            private double m_radius;
            private double m_angle;
            // Properties
            public double Radius { get { return m_radius; } }
            public double Angle { get { return m_angle; } }
            // Constructor
            public UnSafeFooObject_ConstructorAssignment(double p_radius, double p_angle)
            {
                //// Validate
                //p_radius
                //    .MustBeAboveZero("p_radius");
                // Init
                m_radius = p_radius;
                m_angle = p_angle;
            }
        }
        public class UnSafeFooObject_PublicFieldAssignment : IFooObject
        {
            // Public Fields
            public double Radius;
            public double Angle;
        }
    }
    namespace Performance
    {
        public static class Profiler
        {
            // Fields
            private static List<ResultDetails> m_results = new List<ResultDetails>();
            private static readonly object m_syncObject = new object();
            // Properties
            public static string TimerInfo
            {
                get
                {
                    return
                        string.Format("Timer: Frequency = {0:N0}Hz, Resolution = {1:N0}ns\r\n",
                        Stopwatch.Frequency,
                        ((1000L * 1000L * 1000L) / Stopwatch.Frequency));
                }
            }
            // Methods
            public static string Benchmark(string p_methodName, int p_iterations, int p_warmUpCalls, Action p_action)
            {
                // Profiler example http://stackoverflow.com/a/1048708/1718702
                lock (m_syncObject)
                {
                    // Prepare Environment
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    // Warm Up
                    for (int i = 0; i < p_warmUpCalls; i++)
                        p_action();
                    // Profile
                    var MethodTimer = Stopwatch.StartNew();
                    for (int i = 0; i < p_iterations; i++)
                        p_action();
                    MethodTimer.Stop();
                    // Return Results
                    var Details = new StringBuilder();
                    var Ellapsed = MethodTimer.Elapsed.TotalMilliseconds;
                    var Average = (MethodTimer.Elapsed.TotalMilliseconds / (double)p_iterations);
                    Details
                        .AppendFormat("Method: \"{0}\"\r\n", p_methodName)
                        .AppendFormat("Iterations = {0:D}, Warm Up Calls = {1:D}\r\n", p_iterations, p_warmUpCalls)
                        .AppendFormat("Results: Elapsed = {0:N0}ms, Average = {1:N6}ms\r\n", Ellapsed, Average);
                    m_results.Add(new ResultDetails(Average, Details.ToString()));
                    return Details.ToString();
                }
            }
            public static string Ranked_Results(bool p_descending)
            {
                lock (m_syncObject)
                {
                    var sb = new StringBuilder();
                    var OrderedList = (p_descending) ? m_results.OrderByDescending(result => result.Average) : m_results.OrderBy(result => result.Average);
                    double FastestImplementation = OrderedList.Select(r => r.Average).Min();
                    foreach (var Result in OrderedList)
                    {
                        sb
                            .Append(Result.Details.TrimEnd())
                            .AppendFormat(", Efficiency = {0:N2}%", (FastestImplementation / Result.Average) * 100)
                            .AppendLine()
                            .AppendLine();
                    }
                    return sb.ToString();
                }
            }
            public static void Clear()
            {
                lock (m_syncObject)
                {
                    m_results.Clear();
                }
            }
            // Child Class
            private class ResultDetails
            {
                public double Average { get; private set; }
                public string Details { get; private set; }
                public ResultDetails(double p_average, string p_details)
                {
                    Average = p_average;
                    Details = p_details;
                }
            }
        }
    }
