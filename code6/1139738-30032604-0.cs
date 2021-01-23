    using Deedle;
    using System.Linq;
 
    Frame.FromColumns(frame.Columns.Where(kvp => 
      !kvp.Value.As<double>().Values.Any(v => v < 0.0)))
