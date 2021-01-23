    var openers = "([{";
    var closers = ")]}";
    var brackets = new Stack<char>();
    for (int i = 0; i != s.Length; ++i) {
        if (openers.Contains(s[i]))
            brackets.Push(s[i]);
        else if (closers.Contains(s[i])) {
            var opener = openers[closers.IndexOf(s[i])];
            if (brackets.Peek() != opener)
                Console.WriteLine("Mismatched '{0}' at {1}", s[i], i);
            else
                brackets.Pop();
        }
    }
    if (brackets.Count != 0)
        Console.WriteLine("Unmatched '{0}'", brackets.Peek());
