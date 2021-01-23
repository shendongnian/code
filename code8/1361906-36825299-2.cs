    public static string ToSentence(this string src) {
        var retVal = "";
        if (src.Length > 0) {
            List<string> wordCollection = new List<string>();
            int startIndex = 0;
            char[] letters = src.ToCharArray();
            //Skip the First Letter
            var length = letters.Length;
            for (int i = 1; i < length; i++) {
                if (char.IsUpper(letters[i])) {
                    //Check for acronyms
                    if (char.IsUpper(letters[i - 1])
                        && (
                               i == length - 1 ||
                               ((i + 1) < length && (char.IsUpper(letters[i + 1]) || char.IsNumber(letters[i + 1])))
                            )
                    )
                        continue;
                    //Grab Eeverything before Current Index
                    var temp = new String(letters, startIndex, i - startIndex);
                    wordCollection.Add(temp.Trim());
                    startIndex = i;
                }
            }
            wordCollection.Add(new String(letters, startIndex, letters.Length - startIndex));
            retVal = String.Join(" ", wordCollection);
        }
        return retVal;
    }
