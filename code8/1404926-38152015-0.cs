    public static class Extensions
    {
        public static bool Equal<T>(this List<T> x, List<T> y)
        {
            bool isEqual = true;
            if (x == null ^ y == null)
            {
                isEqual = false;
            }
            else if (x == null && y == null)
            {
                isEqual = true;
            }
            else if (x.Equals(y))
            {
                isEqual = true;
            }
            else if (x.Count != y.Count)
            {
                isEqual = false;
            }
            else
            {
                //This logic can be changed as per your need.
                //Here order of the list matters!
                //You can make one where order doesn't matter
                for (int i = 0; i < x.Count; i++)
                {
                    if (!x[i].Equals(y[i]))
                    {
                        break;
                    }
                }
    
            }
            return isEqual;
        }
    }
