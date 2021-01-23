        public static bool AppendUpToMaximumLength(this StringBuilder sb, string str, int maxLen)
        {
            if (sb == null)
                throw new ArgumentNullException("sb");
            if (str == null)
                str = string.Empty; // Or throw an exception if that's your coding convention.
            var sbLen = sb.Length;
            if (sbLen > maxLen)
                return false;
            if (sbLen + str.Length <= maxLen)
            {
                sb.Append(str);
                return true;
            }
            //http://referencesource.microsoft.com/#mscorlib/system/globalization/textelementenumerator.cs
            var enumerator = StringInfo.GetTextElementEnumerator(str);
            while (enumerator.MoveNext())
            {
                var textElement = enumerator.GetTextElement();
                var elemLen = textElement.Length;
                if (sb.Length + elemLen > maxLen)
                    return false;
                sb.Append(textElement);
            }
            return true;
        }
