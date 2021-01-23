    public class CaseSensitiveQueryStringCollection : System.Collections.Specialized.NameValueCollection
    {
        public CaseSensitiveQueryStringCollection(string queryString, bool urlencoded, System.Text.Encoding encoding)
            // This makes it case sensitive, the default is StringComparer.OrdinalIgnoreCase
            : base(StringComparer.Ordinal)
        {
            if (queryString.StartsWith("?"))
            {
                queryString = queryString.Substring(1);
            }
            this.FillFromString(queryString, urlencoded, encoding);
        }
        internal void FillFromString(string s, bool urlencoded, System.Text.Encoding encoding)
        {
            int num = (s != null) ? s.Length : 0;
            for (int i = 0; i < num; i++)
            {
                int startIndex = i;
                int num4 = -1;
                while (i < num)
                {
                    char ch = s[i];
                    if (ch == '=')
                    {
                        if (num4 < 0)
                        {
                            num4 = i;
                        }
                    }
                    else if (ch == '&')
                    {
                        break;
                    }
                    i++;
                }
                string str = null;
                string str2 = null;
                if (num4 >= 0)
                {
                    str = s.Substring(startIndex, num4 - startIndex);
                    str2 = s.Substring(num4 + 1, (i - num4) - 1);
                }
                else
                {
                    str2 = s.Substring(startIndex, i - startIndex);
                }
                if (urlencoded)
                {
                    base.Add(HttpUtility.UrlDecode(str, encoding), HttpUtility.UrlDecode(str2, encoding));
                }
                else
                {
                    base.Add(str, str2);
                }
                if ((i == (num - 1)) && (s[i] == '&'))
                {
                    base.Add(null, string.Empty);
                }
            }
        }
    }
