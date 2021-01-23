     private void RunScript(List<Point3d> SrcPts, List<string> Instrument, List<object> SD_Data, List<double> XY_Angles, List<string> Octave, ref object A, ref object B)
      {
        B = Chunk(SD_Data, 314);
      }
    
      // <Custom additional code> 
    
      public static IEnumerable<IEnumerable<T>> Chunk<T > (IEnumerable<T> source, int chunksize)
      {
        while (source.Any())
        {
          yield return source.Take(chunksize);
          source = source.Skip(chunksize);
        }
      }
      // <Custom additional code>
