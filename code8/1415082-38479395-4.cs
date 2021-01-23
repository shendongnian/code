    private static IEnumerable<String> Nested(string value) {
      if (string.IsNullOrEmpty(value))
        yield break; // or throw exception
      Stack<int> brackets = new Stack<int>();
      for (int i = 0; i < value.Length; ++i) {
        char ch = value[i];
        if (ch == '[')
          brackets.Push(i);
        else if (ch == ']') {
          //TODO: you may want to check if close ']' has corresponding open '['
          // i.e. stack has values: if (!brackets.Any()) throw ...
          int openBracket = brackets.Pop();
          yield return value.Substring(openBracket + 1, i - openBracket - 1);
        }
      }
      //TODO: you may want to check here if there're too many '['
      // i.e. stack still has values: if (brackets.Any()) throw ... 
      yield return value;
    }
...
    string source = "C1 AND [C2 OR C3 OR [C4 OR [C5 AND C6] AND C7]] OR C8";
    var result = Nested(source);
