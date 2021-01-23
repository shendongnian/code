    static void Iterate(int[] iterators, ArrayList[] arrays) {
      for (var j = iterators.Length - 1; j >= 0; j--) {
        iterators[j]++;
        if (iterators[j] == arrays[j].Count) {
          if (j == 0) {
            break;
          }
          iterators[j] = 0;
        } else {
          break;
        }
      }
    }
    static IList<string> Merge(ArrayList[] arrays) {
      List<string> result = new List<string>();
      int[] iterators = new int[arrays.Length];
      while (iterators[0] != arrays[0].Count) {
        var builder = new StringBuilder(20);
        for(var index = 0; index < arrays.Length; index++) {
          if (index > 0) {
            builder.Append("_");
          }
          builder.Append(arrays[index][iterators[index]]);
        }
        result.Add(builder.ToString());
        Iterate(iterators, arrays);
      }
      return result;
    }
    static void Main(string[] args) {
      var list1 = new ArrayList();
      var list2 = new ArrayList();
      var list3 = new ArrayList();
      list1.Add(1);
      list1.Add(2);
      list2.Add("a");
      list2.Add("b");
      list3.Add("x");
      list3.Add("y");
      list3.Add("z");
      var result = Merge(new[] { list1, list2, list3 });
    }
