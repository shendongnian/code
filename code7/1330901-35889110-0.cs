    List<string> folders = new List<string>();
    
    string folderResult = string.Join(",", ParallelMeasurements
        .Select(parallelMeasurement => parallelMeasurement.Item1.Substring(0, parallelMeasurement.Item1.IndexOf(".")))
        .Where(folder => folders.Contains(folder))
        .Select(folder =>
        {
            folders.Add(folder);
            return folder;
        }));
    
    string valueResult = string.Join(",", folders
        .Select(folder => ParallelMeasurements
            .Where(parallelMeasurement => parallelMeasurement.Item1.Substring(0, parallelMeasurement.Item1.IndexOf(".")) == folder))
            .Select(views => views.Sum(view => view.Item2.TotalSeconds)));
