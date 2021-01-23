    string currentTerm = string.Empty;
    State currentState = State.BetweenTerms;
    foreach (char c in valueToParse)
    {
     switch (currentState)
     {
         // if between terms, only need to do something if we encounter a single quote, signalling to start a new term
         // encloser is client-specified char to look for (e.g. ')
         case State.BetweenTerms:
             if (c == encloser)
             {
                 currentState = State.InTerm;
             }
             break;
         case State.InTerm:
             if (c == encloser)
             {
                 if (valueToParse.Length > index + 1 && valueToParse[index + 1] == encloser && valueToParse.Length > index + 2)
                 {
                     // if next character is also encloser then add it and move on
                     currentTerm += c;
                 }
                 else if (currentTerm.Length > 0 && currentTerm[currentTerm.Length - 1] != encloser)
                 {
                     // on an encloser and didn't just add encloser, so we are done
    				 // converterFunc is a client-specified Func<string,T> to return terms in the specified type (to allow for converting to int, for example)
                     yield return converterFunc(currentTerm);
                     currentTerm = string.Empty;
                     currentState = State.BetweenTerms;
                 }
             }
             else
             {
                 currentTerm += c;
             }
             break;
     }
    
     index++;
    }
    
    if (currentTerm.Length > 0)
    {
     yield return converterFunc(currentTerm);
    }
