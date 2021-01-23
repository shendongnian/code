      List<int[]> source = new List<int[]>() {
        new int[] { 1, 5, 7, 5, 5, 3, 4, 9},
        new int[] {0, 1, 2, 3, 4, 6, 3, 4},
        new int[] {9, 4, 6, 7, 0, 0, 3, 1},
        new int[] {4, 6, 3, 7, 8, 0, 0, 1},
        new int[] {8, 0, 3, 1, 0, 2, 4, 6},
      };
      var result = source
        .Select((array, index) => array
          .Where(item => item > index + 2) // +2 since index is zero-based
          .ToArray()); // ToArray is not necessary here, but convenient for further work
      // Test
      String report = String.Join(Environment.NewLine, 
        result.Select(item => String.Join(", ", item)));
      Console.Write(report);
