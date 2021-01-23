    foreach (string str in ViewState.Keys)
    {
        var grades = ViewState[str] as List<double>;
        if(grades != null)
        {
             var average = grades.Average();
        }
    }
