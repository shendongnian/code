    public class HasClaimExtension : MarkupExtension {
        private readonly string _name;
        public HasClaimExtension(string name) {
            _name = name;
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            var service = (IProvideValueTarget) serviceProvider.GetService(typeof (IProvideValueTarget));
            // this is Button or whatever control you set IsEnabled of
            var target = service.TargetObject as FrameworkElement;
            if (target != null) {
                // grab it's DataContext, that is your view model
                var vm = target.DataContext as MyViewModel;
                if (vm != null) {
                    return vm.HasClaim(_name);
                }
            }
            return false;
        }
    }
    public class MyViewModel {
        public bool HasClaim(string claim) {
            return false;
        }
    }
