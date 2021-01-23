     public class SynchronizationHelperExtension : MarkupExtension {
        public Binding Binding { get; set; }
        class Helper {            
            static int index = 0;
            bool locked = false;
            public static readonly DependencyProperty HelperProperty = DependencyProperty.RegisterAttached(
                "Helper", typeof(Helper), typeof(Helper), new PropertyMetadata(default(Helper)));
            public static void SetHelper(DependencyObject element, Helper value) {
                element.SetValue(HelperProperty, value);
            }
            public static Helper GetHelper(DependencyObject element) {
                return (Helper)element.GetValue(HelperProperty);
            }
            public static readonly DependencyProperty FocusProperty = DependencyProperty.RegisterAttached("FocusProperty", typeof(bool), typeof(Helper), new PropertyMetadata(false, (o, args) => GetHelper(o)?.OnFocusPropertyChanged(o, (bool)args.OldValue, (bool)args.NewValue)));            
            public static readonly DependencyProperty SourceProperty = DependencyProperty.RegisterAttached("SourceProperty", typeof(object), typeof(Helper), new PropertyMetadata(false, (o, args) => GetHelper(o)?.OnSourcePropertyChanged(o, args.OldValue, args.NewValue)));
            public static readonly DependencyProperty TargetProperty = DependencyProperty.RegisterAttached("TargetProperty", typeof(object), typeof(Helper), new PropertyMetadata(false, (o, args) => GetHelper(o)?.OnTargetPropertyChanged(o, args.OldValue, args.NewValue)));
            void OnTargetPropertyChanged(DependencyObject o, object oldValue, object newValue) {
                o.SetValue(SourceProperty, newValue);
            }
            void OnSourcePropertyChanged(DependencyObject o, object oldValue, object newValue) {
                if (locked)
                    return;
                o.SetValue(TargetProperty, newValue);
            }
            void OnFocusPropertyChanged(DependencyObject o, bool oldValue, bool newValue) {
                locked = newValue;
            }
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            var helper = new Helper();
            var ipwt = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var dObj = ipwt.TargetObject as DependencyObject;
            BindingOperations.SetBinding(dObj, Helper.FocusProperty, new Binding() {Path = new PropertyPath(FrameworkElement.IsKeyboardFocusWithinProperty), RelativeSource = RelativeSource.Self});
            Binding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(dObj, Helper.SourceProperty, Binding);
            Helper.SetHelper(dObj, helper);
            return new Binding() {Path = new PropertyPath(Helper.TargetProperty), Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.LostFocus, RelativeSource = RelativeSource.Self }.ProvideValue(serviceProvider);
        }
    }
