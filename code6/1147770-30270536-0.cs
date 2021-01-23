        bool InRange(decimal num, decimal value, decimal range)
        {
            return ((num >= value - range) && (num < value + range));
        }
        decimal GetClosestSum(decimal value, List<decimal> elements, decimal range)
        {
            elements.Sort();
            var possibleResults = new List<decimal>();
            for (int x = elements.Count - 1; x > 0; x--)
            {
                if (InRange(elements[x], value, range)) possibleResults.Add(elements[x]);
                decimal possibleResult = elements[x];
                for (int i = x - 1; i > -1; i--)
                {
                    possibleResult += elements[i];
                    if (possibleResult > (value + range - 1)) possibleResult -= elements[i];
                    if (InRange(possibleResult, value, range)) possibleResults.Add(possibleResult);
                }
            }
            decimal bestResult = -1;
            for (int x = 0; x < possibleResults.Count; x++)
            {
                if (bestResult == -1)
                    bestResult = possibleResults[x];
                if (Math.Abs(value - possibleResults[x]) < Math.Abs(value - bestResult))
                    bestResult = possibleResults[x];
            }
            return bestResult;
        }
