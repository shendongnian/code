    public class Emails : ObservableCollection<Email> {
        public Emails() {
        }
        public Emails(IEnumerable<Email> emails) {
            foreach (var e in emails) {
                Add(e);
            }
        }
        public IEnumerable<Email> GetAll() {
            return Items;
        }
        protected bool InsertItem(int index, Email item, bool throwOnInvalidEmailAddress = false) {
            if (IsValidEmailAddress(item.Address)) {
                base.InsertItem(index, item);
                return true;
            }
            if (throwOnInvalidEmailAddress)
                throw new Exception("Bad email address!");
            return false;
        }
        protected bool SetItem(int index, Email item, bool throwOnInvalidEmailAddress = false) {
            if (IsValidEmailAddress(item.Address)) {
                base.SetItem(index, item);
                return true;
            }
            if (throwOnInvalidEmailAddress)
                throw new Exception("Bad email address!");
            return false;
        }
        public bool Add(Email item, bool throwOnInvalidEmailAddress = false) {
            if (IsValidEmailAddress(item.Address)) {
                base.Add(item);
                return true;
            }
            if (throwOnInvalidEmailAddress)
                throw new Exception("Bad email address!");
            return false;
        }
        private static readonly Regex EmailValidatorRegex = 
            new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$");
        private bool IsValidEmailAddress(string address) {
            return !string.IsNullOrWhiteSpace(address) && EmailValidatorRegex.IsMatch(address);
        }
    }
