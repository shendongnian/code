                    if (i + length <= s.Length)
                    {
                        yield return s.Substring(i, length);
                    }
                    else if(s[i] == ' ')
                    {
                        yield return s.Substring(i, s.IndexOf(" ",i) - i);
                    }
                    else
                    {
                        yield return s.Substring(i);
                    }
