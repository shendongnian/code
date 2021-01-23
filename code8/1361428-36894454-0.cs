    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var categories = PerformanceCounterCategory.GetCategories();
    
                foreach (var cat in categories)
                {
                    if (cat.CategoryType != PerformanceCounterCategoryType.MultiInstance)
                    {
                        Console.WriteLine("Category: " + cat.CategoryName);
                        foreach (var counter in cat.GetCounters())
                        {
                            Console.WriteLine("Counter: " + counter.CounterName + ": " + counter.NextSample().RawValue);
                        }
                    }
                    else //if (cat.CategoryType == PerformanceCounterCategoryType.MultiInstance)
                    {
                        foreach (var instance in cat.GetInstanceNames())
                        {
                            Console.WriteLine("Instance: " + instance);
                            foreach (var counter in cat.GetCounters(instance))
                            {
                                try
                                {
                                    Console.WriteLine("Counter: " + counter.CounterName + ": " + counter.NextSample().RawValue);
                                } catch
                                { 
                                    // swallow exceptions for counter that require a set base. 
                                }
                            }
                        }
                    }
                }
    
                Console.ReadLine();           
            }      
        }
    }
