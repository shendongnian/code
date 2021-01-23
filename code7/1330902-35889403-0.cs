     var folders = new List<string>();
     string folderResult = "";
     
    foreach (var folder in ParallelMeasurements.Select(parallelMeasurement =>    parallelMeasurement.
                             Item1.Substring(0, parallelMeasurement.Item1.IndexOf("."))).
                             Where(folder => !folders.Contains(folder)))
    {
         folders.Add(folder);
         folderResult += folder + ",";
    }
    folderResult = folderResult.TrimEnd(',');
    string valueResult = folders.Select(folder => ParallelMeasurements.
                                        Where(x => x.Item1.Substring(0, x.Item1.IndexOf(".")) == 
               folder)).Select(views => views.Sum(x => x.Item2.TotalSeconds)).Aggregate("", (current, value) => current + (value + ","));
      valueResult = valueResult.TrimEnd(',');
