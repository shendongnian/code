    public class HasClaimExtension : MarkupExtension {
        private readonly string _name;
        public HasClaimExtension(string name) {
            _name = name;
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            if (LoginManager.Instance.IsLoggedIn) {
                return LoginManager.Instance.HasClaim(_name);
            }
            // if not logged in yet
            var service = (IProvideValueTarget) serviceProvider.GetService(typeof (IProvideValueTarget));
            var target = service.TargetObject as FrameworkElement;
            // this is dependency property you want to set, IsEnabled in this case
            var targetProperty = service.TargetProperty as DependencyProperty;
            if (target != null && targetProperty != null) {
                if (targetProperty.PropertyType != typeof (bool)) {
                    // not boolean property - throw
                    throw new Exception("HasClaim extension should be applied to Boolean properties only");
                }
                // here, subscribe to event after which your claims are available
                LoginManager.Instance.OnLoggedIn += () => {
                    // update target property
                    if (Application.Current.Dispatcher.CheckAccess())
                        target.SetValue(targetProperty, LoginManager.Instance.HasClaim(_name));
                    else {
                        Application.Current.Dispatcher.Invoke(() => {
                            target.SetValue(targetProperty, LoginManager.Instance.HasClaim(_name));
                        });
                    }
                };
            }
            return false;
        }
    }
