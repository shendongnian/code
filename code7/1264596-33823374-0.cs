    var triangle = "5#9#6#4#6#8#0#7#1#5";
    var values = triangle.Split('#').Select(Int32.Parse).ToList();
    var sizeAsDouble = (-1 + Math.Sqrt(1 + 8*values.Count))/2;
    var size = (Int32) sizeAsDouble;
    if (sizeAsDouble != size)
      // Do not use Exception in production code.
      throw new Exception("Input data is not a triangle.");
