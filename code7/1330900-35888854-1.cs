    var folders = new List<string>();
    foreach (var parallelMeasurement in ParallelMeasurements)
    {
        folders.Add(parallelMeasurement.Item1.Substring(0, parallelMeasurement.Item1.IndexOf(".")));
    }
    string folderResult = String.Join(',', folders.Disctint().toList());
    
    var values = new List<int>();
    foreach (var folder in folders)
    {
        values.Add(ParallelMeasurements.Where(x => x.Item1.Substring(0, x.Item1.IndexOf(".")) == folder).Sum(x => x.Item2.TotalSeconds));
    }
    string valueResult = String.Join(',', values);
