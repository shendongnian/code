    public class HasClaimExtension : MarkupExtension {
        private readonly string _name;
        public HasClaimExtension(string name) {
            _name = name;
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return HasClaim();
        }
        private bool HasClaim() {
            // check if user has this claim here
            if (_name.ToLowerInvariant() == "admin")
                return true;
            return false;
        }
    }
