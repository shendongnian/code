        private void InitializeValidation()
        {
            FrameworkElement SelectedObject = Txt0;
            DependencyProperty property =
                GetDependencyPropertyByName(SelectedObject, "TextProperty");
            Binding binding = new Binding("Model.Txt0");
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.ValidatesOnDataErrors = true;
            RequiredValidate role = new RequiredValidate();
            binding.ValidationRules.Add(role);
            SelectedObject.SetBinding(property, binding);
        }
        public static DependencyProperty GetDependencyPropertyByName(DependencyObject dependencyObject, string dpName)
        {
            return GetDependencyPropertyByName(dependencyObject.GetType(), dpName);
        }
        public static DependencyProperty GetDependencyPropertyByName(Type dependencyObjectType, string dpName)
        {
            DependencyProperty dp = null;
            var fieldInfo = dependencyObjectType.GetField(dpName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (fieldInfo != null)
            {
                dp = fieldInfo.GetValue(null) as DependencyProperty;
            }
            return dp;
        }
