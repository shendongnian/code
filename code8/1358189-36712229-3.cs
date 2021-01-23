    IEnumerable<int> seq1 = Enumerable.Range(1, 5);
    IEnumerable<int> seq2 = null;
    IEnumerable<int> seq3 = Enumerable.Range(6, 5);
    IEnumerable<int> seq4 = null;
    IEnumerable<int> seq5 = Enumerable.Range(11, 5);
    var numbers = ConcatTreatingNullsAsEmpty(seq1, seq2, seq3, seq4, seq5);
    Console.WriteLine(string.Join(", ", numbers)); // Prints 1, 2, ..., 14, 15
