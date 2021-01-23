       public class SpecialComparer : IComparer<string>
            {
                public int Compare(string x, string y)
                {
                    if (x.Equals(y))
                        return 0;
    
                    int yn;
                    int xn;
                    bool isXNumber = int.TryParse(x, out xn);
                    bool isYNumber = int.TryParse(y, out yn);
    
                    if (isXNumber && isYNumber)
                    {
                        return xn.CompareTo(yn);
                    }
                    else if (isXNumber && !isYNumber)
                    {
                        return -1;
                    }
                    else if (!isXNumber && isYNumber)
                    {
                        return 1;
                    }
                    else if(x.Any(c => c == '/' || c == '-' ) || y.Any(c => c == '/' || c == '-'))
                    {
                        var xParts = x.Split("/-".ToCharArray(),  StringSplitOptions.RemoveEmptyEntries);
                        var yParts = y.Split("/-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    
                        var minLen = Math.Min(xParts.Length, yParts.Length);
    
                        var result = 0;
                        for (int i = 0; i < minLen; i++)
                            if ((result = Compare(xParts[i], yParts[i])) != 0)
                                return result;
    
                        return x.Length < y.Length ? -1 : 1;
                    }
                    else
                    {
                        return x.CompareTo(y);
                    }
                }
            }
