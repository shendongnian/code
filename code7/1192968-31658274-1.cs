        private static IEnumerable<string> ReplaceWithLine(StringBuilder sb, string search,string replace)
        {
            StringBuilder sbline = new StringBuilder();
            for (int i = 0; i < sb.Length; i++)
            {
                char ch = sb[i];
                if (ch == '\n' || i == sb.Length - 1)
                {
                    if (sbline.ToString().Contains(search))
                    {
                        yield return replace;
                    }
                    else
                    {
                        yield return sbline.ToString();
                    }
                    sbline.Clear();
                }
                else
                {
                    sbline.Append(ch);
                }
            }
        }
