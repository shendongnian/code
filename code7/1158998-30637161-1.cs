    public partial class user: IPKProvider
    {
        public bool PKHasNoValue() {
            return string.IsNullOrEmpty(this.username);
        }
    }
