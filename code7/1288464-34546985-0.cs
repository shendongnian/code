        public class ListComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (x == null)
                {
                    if (y == null)
                    {
                        // If x is null and y is null, they're
                        // equal. 
                        return 0;
                    }
                    else
                    {
                        // If x is null and y is not null, y
                        // is greater. 
                        return -1;
                    }
                }
                else
                {
                    // If x is not null...
                    //
                    if (y == null)
                    // ...and y is null, x is greater.
                    {
                        return 1;
                    }
                    else
                    {
                        // ...and y is not null, compare the 
                        // int values of the two strings.
                        //
                        return Convert.ToInt32(x).CompareTo(Convert.ToInt32(y));
                    }
                }
            }
        }
