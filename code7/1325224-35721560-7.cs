    List<string> SelectedStartDates = new System.Collections.Generic.List<string>();
    List<string> SelectedEndDates = new System.Collections.Generic.List<string>();
    List<DateTime> combine = new List<DateTime>();
    for (int i = 0; i < SelectedStartDates.Count; i++)
    {
        combine.Add(DateTime.Parse(SelectedStartDates[i]));
        combine.Add(DateTime.Parse(SelectedEndDates[i]));
    }
