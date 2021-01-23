     public static IEnumerable<string> Split(this string text, char separator, char escapeCharacter, bool removeEmptyEntries)
     {
         string buffer = string.Empty;
         bool escape = false;
         foreach (var c in text)
         {
             if (!escape && c == separator)
             {
                 if (!removeEmptyEntries || buffer.Length > 0)
                 {
                     yield return buffer;
                 }
                 buffer = string.Empty;
             }
             else
             {
                 if (c == escapeCharacter)
                 {
                     escape = !escape;
                     if (!escape)
                     {
                         buffer = string.Concat(buffer, c);
                     }
                 }
                 else
                 {
                     if (!escape)
                     {
                         buffer = string.Concat(buffer, c);
                     }
                     escape = false;
                 }
             }
         }
            if (buffer.Length != 0)
            {
                yield return buffer;
            }
        }
