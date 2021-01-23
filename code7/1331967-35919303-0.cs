    int[] userVector = new int[] {
      1001, 1002, 1003, 1004, 1005, 1006, 1007,
    };
    int[] filteredUserVector = new int[] {
      1001, 1002, 1004, 1006
    };
    
    ....
    HashSet<int> filtered = new HashSet<int>(filteredUserVector);
    
    Boolean[] theResultArray = userVector
      .Select(item => filtered.Contains(item))
      .ToArray();
    // Test:
    // True, True, False, True, False, True, False
    Console.Write(String.Join(", ", theResultArray)); 
