    public static string ExtractBetween(this string str, string startTag, string endTag, bool inclusive)
        {
            string rtn = null;
            var s = str.IndexOf(startTag);
            if (s >= 0)
            {
                if (!inclusive)
                {
                    s += startTag.Length;
                }
                var e = str.IndexOf(endTag, s);
                if (e > s)
                {
                    if (inclusive)
                    {
                        e += startTag.Length +1;
                    }
                    rtn = str.Substring(s, e - s);
                }
            }
            return rtn;
        }
