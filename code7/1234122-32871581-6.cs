    public static string RemoveVowels(string name)
    {
        StringBuilder noVowels = new StringBuilder();
        //keep track of the last index we read
        int lastIndex = 0;
            
        int i;
        for (i = 0; i < name.Length; i++)
        {
            if (vowels.Contains(name[i]))
            {
                //the current index is a vowel, take the text from the last read index to this index
                noVowels.Append(name, lastIndex, i - lastIndex);
                lastIndex = i + 1;
            }
        }
        if (lastIndex < i)
        {
            //the last character wasn't a vowel so we need to add the rest of the string here.
            noVowels.Append(name, lastIndex, name.Length - lastIndex);
        }
        return noVowels.ToString();
    }
