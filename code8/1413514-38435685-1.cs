    public static List<double> sortDoppelganger(List<double> inputFitnessList)
    {
        List<double> newFitnessList = inputFitnessList.ToList();
        for (int i = 0; i < newFitnessList.Count; i++)
        {
            double Nothing = 0;
            double actual = newFitnessList[i];
            for (int j = newFitnessList.Count - 1; j >= 0; j--)
            {
                if (j == i)
                    continue;
    
                double next = newFitnessList[j];
                if (actual == next)
                {
                    newFitnessList[j] = Nothing;
                }
            }
        }
        return newFitnessList;
    }
