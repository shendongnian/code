    namespace your.namespace
    {
        using Microsoft.Xaml.Interactivity;
        using Windows.UI.Xaml;
        using Windows.UI.Xaml.Controls.Primitives;
        using Windows.UI.Xaml.Input;
        public class OpenMenuFlyoutAction : DependencyObject, IAction
        {
            private static object holdedObject;
            public object Execute(object sender, object parameter)
            {
                FrameworkElement senderElement = sender as FrameworkElement;
                FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
                flyoutBase.ShowAt(senderElement);
                var eventArgs = parameter as HoldingRoutedEventArgs;
                if (eventArgs == null)
                {
                    return null;
                }
                var element = eventArgs.OriginalSource as FrameworkElement;
                if (element != null)
                {
                    HoldedObject = element.DataContext;
                }
                return null;
            }
            public static object HoldedObject
            {
                get { return holdedObject; }
                set
                {
                    holdedObject = value;
                }
            }
        }
    }
