    public static IEnumerable<char> Decompress(string compressed)
    {
        foreach(var c in compressed)
        {
            if(c == 'ú')
            {
                var characterToRepeat = ' '; // TODO: Get character to repeat
                var countOfRepeats = 1; // TODO: Get count of repeats
                foreach(var character in Enumerable.Repeat(characterToRepeat, countOfRepeats))
                    yield return character;
            }
            else
                yield return c;
        }
    }
