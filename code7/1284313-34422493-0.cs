    public static string RemoveIllegalFilenameCharactersFrom(string unsafeString)
        {
            const string illegalCharactersClass = @"[\&\<\>\:/|" + "\"" + @"\?\*]";
    
            string replaced = Regex.Replace(unsafeString, illegalCharactersClass, "");
    
            return replaced;
        }
