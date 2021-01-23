        public static string FormatString(string format, 
                                          object[] args, 
                                          out FormattedStringPart[] formattedParts)
        {
            var parts = new List<FormattedStringPart>();
            var result = new StringBuilder();
            int i = 0;
            while (i < format.Length)
            {
                char c = format[i];
                if (c == '{')
                {
                    int j = format.IndexOf('}', i);
                    if (j < 0)
                        throw new FormatException("Missing '}'");
                    int startIndex = result.Length;
                    result.AppendFormat(format.Substring(i, (j - i) + 1), args);
                    ++i;
                    // the AppendFormat call should have ensured there's a
                    // valid number following...
                    int objectIndex = 0;
                    while (format[i] >= '0' && format[i] <= '9')
                    {
                        objectIndex *= 10;
                        objectIndex += (int)(format[i] - '0');
                        ++i;
                    }
                    parts.Add(new FormattedStringPart(objectIndex, 
                                                      startIndex, 
                                                      result.Length - startIndex));
                    i = j + 1;
                }
                else
                {
                    result.Append(c);
                    ++i;
                }
            }
            if (parts.Count == 0)
                formattedParts = null;
            else
                formattedParts = parts.ToArray();
            return result.ToString();
        }
