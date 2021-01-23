    List<List<Point3d>> currentGeneration = handoverPopulation.ToList();
    List<double> currentFitness = handoverFitness.ToList();
    Dictionary<List<Point3d>, double> dict = new Dictionary<List<Point3d>, double>();
    foreach(List<Point3d> key in currentGeneration)
    {
      foreach(double valuee in currentFitness)
      {
        if(!dict.ContainsKey(key))
        {
          if(!dict.ContainsValue(valuee))
          {dict.Add(key, valuee);}
        }
      }
    }
    var item = from pair in dict orderby pair.Value ascending select pair;
    List<List<Point3d>> currentGenerationSorted = new List<List<Point3d>>();
    currentGenerationSorted = item.Select(kvp => kvp.Key).ToList();
    List<List<Point3d>> newGeneration = new List<List<Point3d>>();
    List<List<Point3d>> newGenerationExtra = new List<List<Point3d>>();
    int p = currentGenerationSorted.Count / 2;
    for(int i = 0; i < p; i++)
    {newGeneration.Add(currentGenerationSorted[i]);}
    for(int j = p; j < currentGenerationSorted.Count; j++)
    {newGenerationExtra.Add(currentGenerationSorted[j]);}
