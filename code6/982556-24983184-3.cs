    var key = new string(Enumerable.Range(1, length)
                                   .Select(i => (char)i)
                                   .Where(c => Char.IsPunctuation(c)
                                               || Char.IsLetterOrDigit(c))
                                   .ToArray());
