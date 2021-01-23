        public class AddToInputBinding
        {
            public static System.Windows.Input.InputBinding GetBinding(DependencyObject obj)
            {
                return (System.Windows.Input.InputBinding)obj.GetValue(BindingProp);
            }
            public static void SetBinding(DependencyObject obj, System.Windows.Input.InputBinding value)
            {
                obj.SetValue(BindingProp, value);
            }
            
            public static readonly DependencyProperty BindingProp = DependencyProperty.RegisterAttached(
              "Binding", typeof(System.Windows.Input.InputBinding), typeof(AddToInputBinding), new PropertyMetadata
              {
                  PropertyChangedCallback = (obj, e) =>
                  {
                      ((UIElement)obj).InputBindings.Add((System.Windows.Input.InputBinding)e.NewValue);
                  }
              });
        }
