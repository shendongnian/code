    var res = String.Join("", Char.IsLetter(input.First()) ? 
                              input.TakeWhile(c => Char.IsLetter(c))) :
                              input.SkipWhile(c => c != '.')
                                   .SkipWhile(c => c == '.')
                                   .TakeWhile(c => Char.IsLetter(c)));
