    var set = new int[,] {
      { 1, 2, 3 },
      { 4, 5, 6 },
      { 7, 8, 0 }
    };
    var clone = (int[,])set.Clone();
    var foo = clone == set; // foo is false
    var bar = clone.Equals(set); // bar is false
    var closedStates = new List<int[,]>();
    closedStates.Contains(state); // wrong - contains is using Equals
    closedStates.Any(cs => AreEqual(cs, state)); // correct
    static bool AreEqual(int[,] stateA, int[,] stateB) {
      for (var x = 0; x < DIMENSIONS; x++) {
        for (var y = 0; y < DIMENSIONS; y++) {
          if (stateA[x, y] != stateB[x, y]) {
            return false;
          }
        }
      }
      return true;
    }
      
   
    
