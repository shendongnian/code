    public static class StringUtils
    {
        public static string TrimToLength(this string input, string separator, int targetLength)
        {
            var splitInput = input.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    
            var length = splitInput[0].Length;
            var targetIndex = 1;
    
            for (targetIndex = 1; length <= targetLength; targetIndex++)
                length += separator.Length + splitInput[targetIndex].Length;
    
            if (length > targetLength)
                targetIndex--;
    
            var splitOutput = new string[targetIndex];
            Array.Copy(splitInput, 0, splitOutput, 0, targetIndex);
    
            return string.Join(separator, splitOutput);
        }
    }
