      String[] names = new String[] { "A", "B", "C" };
      var lines = Enumerable
        .Range(0, 1 << names.Length) // 1 << count == 2 ** count
        .Select(item => String.Join(" and ", Enumerable
           .Range(0, names.Length)
           .Select(index => names[index] +
                            ((item >> index) % 2 == 0 ? " != null" : " == null"))));
      // Let's print out all the lines generated
      Console.Write(String.Join(Environment.NewLine, lines));
