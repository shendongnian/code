    public static List<int> DefMarkerX = new List<int>;
    for (int i = 0; i < MarkerPosX.Count; i++)
    {
       if (MarkerPosX[i] > 10 && MarkerPosX[i] < 246 && MarkerPosY[i] > 10 && MarkerPosY[i] < 246)
       {
           DefMarkerX.Add(MarkerPosX[i]);
       }
    }
