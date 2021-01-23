      public IEnumerable<String> GetDataLinesFromFile(filePath) {
        // Check that neither ReadAllLines nor ReadAllText is there
        // Check absence of ToList() and ToArray() as well
        return File
          .ReadLines(filePath) // the only possible way of reading file
          .Select(...) // possible, but not necessary part
          .Where(...); // possible, but not necessary part
      }
 
