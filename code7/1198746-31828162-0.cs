        public class TriggerActionClick : TriggerAction<Button>
    {
        public string Value { get; set; }
        public string TargetName { get; set; }
        protected override void Invoke(object parameter)
        {
            if (AssociatedObject.DataContext != null && !string.IsNullOrEmpty(TargetName))
            {
                var type=AssociatedObject.DataContext.GetType();
                var prop = type.GetProperty(TargetName);
                if (prop != null)
                    prop.SetValue(AssociatedObject.DataContext,Value);
            }
        }
    }
