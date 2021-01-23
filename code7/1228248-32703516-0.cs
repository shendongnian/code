    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<List<decimal>> listOfLists = new List<List<decimal>>()
                {
                    new List<decimal>() { 1, 2, 3 },
                    new List<decimal>() { 3, 4, 5 },
                    new List<decimal>() { 5, 6, 7 },
                };
                PrintAllCombinationsForTargetValue(listOfLists, 12);
            }
            private static void PrintAllCombinationsForTargetValue(List<List<decimal>> listOfLists, decimal targetValue)
            {
                Stack<decimal> currentCombination = new Stack<decimal>();
                FindNextElement(listOfLists, targetValue, 0, 0, currentCombination);
            }
            private static void FindNextElement(List<List<decimal>> listOfLists, decimal targetValue, int listIndex, decimal trackingValue, Stack<decimal> currentCombination)
            {
                List<decimal> currentList = listOfLists[listIndex];
                foreach (decimal currentValue in currentList)
                {
                    decimal currentTrackingValue = trackingValue + currentValue;
                    currentCombination.Push(currentValue);
                    if (currentTrackingValue < targetValue && listIndex < listOfLists.Count - 1)
                    {
                        // There is still la chance that we can get what we want. Let's go to the next list.
                        FindNextElement(listOfLists, targetValue, listIndex + 1, currentTrackingValue, currentCombination);
                    }
                    else if (currentTrackingValue == targetValue && listIndex == listOfLists.Count - 1)
                    {
                        // Found a valid combination!
                        currentCombination.Reverse().ToList().ForEach(element => Console.Write(element + " "));
                        Console.WriteLine();
                    }
                    currentCombination.Pop();
                }
            }
        }
    }
