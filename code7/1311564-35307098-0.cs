     private void CalculateYValue()
     {
        double temp = 0;
        for (int index=0;index<DataPoints.Count;index++)
        {
            temp += DataPoints[index].Movement;
            DataPoints[index].YValue += temp;
        }
    }
