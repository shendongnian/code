    var lines = CartesianProduct(all, 0);
    foreach(var line in lines) {
       Console.WriteLine(line);
    }
    List<string> CartesianProduct(List<item> items, int level) {
       List<string> result = new List<string>();
       List<string> itemsOnThisLevel = new List<string>();
       foreach(var it in items) {
          if (it.level == level) itemsOnThisLevel.Add(it.name);
       }
       if (!itemsOnThisLevel.Any()) {
          result.Add("");
          return result;
       }
       var itemsOnLowerLevels = CartesianProduct(items, level+1);
       foreach(var it in itemsOnThisLevel) {
          foreach(var it2 in itemsOnLowerLevels) {
             result.Add(it2 + " - " + it);
          } 
       }
       return result
    }
