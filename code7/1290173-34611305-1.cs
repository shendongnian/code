    List<CatValue> listOfPieSlices = new List<CatValue>();
    // ....
    // Add your data to the list object
    // ....
    // Sort the list in ascending order
    listOfPieSlices.Sort((x, y) => x.Value.CompareTo(y.Value));
    // Sort the list in descending order
    // listOfPieSlices.Sort((x, y) => -x.Value.CompareTo(y.Value));
    //
    // Now sort the "listOfPieSlices" with the specialSort methode:
    listOfPieSlices = specialSort<CatValue>(listOfPieSlices);
    
    // Now create the Series of DataPoints
    Series sortedPoints = new Series("PCDSsorted");
    for (int i = 0; i < listOfPieSlices.Count; i++)
    {
        sortedPoints.Points.AddY(Math.Abs(listOfPieSlices[i].Value));        
        sortedPoints.Points[i].Label = listOfPieSlices[i].CategoryName + ":  "+listOfPieSlices[i].Value.ToString();
        sortedPoints.Points[i].Font = new Font("Microsoft Sans Serif", 12);
        sortedPoints.Points[i].LabelToolTip = listOfPieSlices[i].Tooltip;
        sortedPoints.Points[i].ToolTip = listOfPieSlices[i].Tooltip;
    }    
    private List<T> specialSort<T>(List<T> objects)
    {
        if (objects == null) return null;
        int count = objects.Count;
        List<T> sortedList = new List<T>();
        for (int i = 0; i <= count - 1; i += 2)
        {
            if(i == count - 1)
                sortedList.Add(objects[i / 2]);
            else
            {
                sortedList.Add(objects[i / 2]);
                sortedList.Add(objects[count - 1 - (i / 2)]);
            }
        }
        return sortedList;
    }
