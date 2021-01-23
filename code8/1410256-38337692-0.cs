    public abstract class AbsAccount 
    {
        public abstract int CountElements { get; }
    }
    public class Account: AbsAccount 
    {
        private List<string> accountHolders;
        private List<string> phoneNumbers;
        private List<string> addresses;
        public override int CountElements
        {
            get 
            {
                return this.accountHolders.Count() 
                    + this.phoneNumbers.Count() 
                    + this.addresses.Count(); 
            }
        }
    }
    public class AccountParser
    {
        // Some code
        public int CountElements(AbsAccount acct)
        {
            return acct.CountElements;
        }
    }
