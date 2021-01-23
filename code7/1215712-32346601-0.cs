    /// <summary>
    /// Utilities to be used with common data binding issues
    /// </summary>
    class DataBindingUtils
    {
        private static readonly DependencyProperty DummyProperty = DependencyProperty.RegisterAttached(
              "Dummy",
              typeof(Object),
              typeof(DependencyObject),
              new UIPropertyMetadata(null));
        /// <summary>
        /// Get a binding expression source value (using the PropertyPath), from MSDN forums:
        /// "Yes, there is one (class to provide the value) inside WPF stack, but it's an internal class"
        /// Get source value of the expression by creating new expression with the same
        /// source and Path, attaching this expression to attached property of type object
        /// and finally getting the value of the attached property
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static Object Eval(BindingExpression expression)
        {
            // The path might be null in case of expression such as: MyProperty={Binding} - in such case the value we'll get
            // will be the DataContext
            string path = null;
            if (expression.ParentBinding != null && expression.ParentBinding.Path != null)
            {
                path = expression.ParentBinding.Path.Path;
            }
            Binding binding = new Binding(path);
            binding.Source = expression.DataItem;
            DependencyObject dummyDO = new DependencyObject();
            BindingOperations.SetBinding(dummyDO, DummyProperty, binding);
            object bindingSource = dummyDO.GetValue(DummyProperty);
            BindingOperations.ClearBinding(dummyDO, DummyProperty);
            return bindingSource;
        }
    }
