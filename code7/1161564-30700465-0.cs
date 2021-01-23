    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static List<decimal> inputs = new List<decimal> { 10, 20, 30, 40 };
            static void Main(string[] args)
            {
                inputs.Sort();
                int level = 0;
                decimal target = 50;
                Solution solution = new Solution();
                List<decimal> elements = new List<decimal>();
                solution.Solve(elements, target,level);
            }
            public class Solution
            {
                private static bool first = true;
                public static decimal Sum = -1;
                public static decimal error = -1;
                public static List<decimal> elements = new List<decimal>();
                public static bool BestSolution(List<decimal> newSolution, decimal target)
                {
                    bool higher = false;
                    if(first == true)
                    {
                        AddSolution(newSolution, target);
                        first = false;
                    }
                    else
                    {
                        decimal newError = Math.Abs(newSolution.Sum() - target);
                        if(newError < error)
                        {
                            AddSolution(newSolution, target);
                        }
                        else
                        {
                            if((newError == error) && (newSolution.Count < elements.Count))
                            {
                                AddSolution(newSolution, target);
                            }
                        }
                    }
                    if(elements.Sum() > target) higher = true;
                    return higher;
                }
                private static void AddSolution(List<decimal> newSolution, decimal target)
                {
                    Sum = newSolution.Sum();
                    error = Math.Abs(newSolution.Sum() - target);
                    elements = new List<decimal>(newSolution);
                }
                public void Solve(List<decimal> localElements, decimal target, int level)
                {
                    for (int i = level; i < inputs.Count; i++)
                    {
                        List<decimal> newElements = new List<decimal>(localElements);
                        newElements.Add(inputs[i]);
                        if (!Solution.BestSolution(newElements, target))
                        {
                            
                            Solve(newElements, target, level + 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
    ​
