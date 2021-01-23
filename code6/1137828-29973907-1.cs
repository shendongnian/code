    private static List<int> GetValleys(List<int> arraySmoothed)
    {
        List<int> valleys = new List<int>();
        List<int> tempValley = new List<int>();
        for (int i = 1; i < arraySmoothed.Count - 1; i++)
        {
            // A[i] is minima if A[i-1] >= A[i] <= A[i+1], <= instead of < is deliberate 
            // otherwise it won't work for consecutive repeating minima values for a valley
            bool isValley = arraySmoothed[i - 1] >= arraySmoothed[i]
                && arraySmoothed[i] <= arraySmoothed[i + 1];
            // If several equal minima values for same valley, average the indexes 
            // keeping in temp list
            if (isValley)
            {
                tempValley.Add(i);
            }
            else
            {
                if (tempValley.Any())
                {
                    if (arraySmoothed[i] <= arraySmoothed[i + 1])
                    {
                        valleys.Add((int)tempValley.Average());
                    }
                    tempValley.Clear();
                }
            }
        }
        return valleys;
    }
