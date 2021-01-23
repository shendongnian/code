            int[] intArray = { 20, 30, 40, 50, 60, 50, 40, 30, 20, 10 };
            int numberToFind = 0;
            //variant 1 (using System.Linq):
            bool bInside1 = intArray.Contains(numberToFind);
            //variant2
            bool bInside2 = Array.IndexOf(intArray, numberToFind) >= 0;
