    string wordToMatch = "(Four)";
                string sentence = "Maybe the fowl of Uruguay repeaters (Four) will be found";
    
                if (sentence.Contains(wordToMatch))
                {
                    int length = wordToMatch.Trim(new[] { '(', ')' }).Length;
                    int indexOfMatchedWord = sentence.IndexOf(wordToMatch);
                    string subString1 = sentence.Substring(0, indexOfMatchedWord);
                    string[] words = subString1.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var reversed = words.Reverse().Take(length);
    
                    string result = string.Join(" ", reversed.Reverse());
                    Console.WriteLine(result);
                    Console.ReadLine();
                }
