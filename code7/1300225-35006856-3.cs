    public class NameSorter : Comparer<Contact>
    {
        public override int Compare(Contact x, Contact y)
        {
            int result = x.LastName.First().CompareTo(y.LastName.First());
    
            if (result != 0)
            {
                return result;
            }
            else
            {
                result = x.LastName.CompareTo(y.LastName);
    
                if (result != 0)
                {
                    return result;
                }
                else
                {
                    return x.FirstName.CompareTo(y.FirstName);
                }
            }
        }
    }
    
    public class StateSorter : Comparer<Contact>
    {
        public override int Compare(Contact x, Contact y)
        {
            int result = x.State.CompareTo(y.State);
    
            if (result != 0)
            {
                return result;
            }
            else
            {
                result = x.LastName.CompareTo(y.LastName);
    
                if (result != 0)
                {
                    return result;
                }
                else
                {
                    return x.FirstName.CompareTo(y.FirstName);
                }
            }
        }
    }
