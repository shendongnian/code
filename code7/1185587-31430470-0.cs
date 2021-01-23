    public class StringArrayEqualityComparer : IEqualityComparer<string[]>
            {
                public bool Equals(string[] x, string[] y)
                {
                    return x.SequenceEqual(y);
                }
                public int GetHashCode(string[] obj)
                {
                    return obj.GetHashCode();
                }
            }
