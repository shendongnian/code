    class MyHyperLinkBehavior : Behavior<Hyperlink>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += AssociatedObject_Click;
        }
        public static bool GetIsFemale(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFemaleProperty);
        }
        public static void SetIsFemale(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFemaleProperty, value);
        }
        // Using a DependencyProperty as the backing store for IsFemale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFemaleProperty =
            DependencyProperty.RegisterAttached("IsFemale", typeof(bool), typeof(MyHyperLinkBehavior), new PropertyMetadata(false));
        public static string GetSalutation(DependencyObject obj)
        {
            return (string)obj.GetValue(SalutationProperty);
        }
        public static void SetSalutation(DependencyObject obj, string value)
        {
            obj.SetValue(SalutationProperty, value);
        }
        // Using a DependencyProperty as the backing store for Salutation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SalutationProperty =
            DependencyProperty.RegisterAttached("Salutation", typeof(string), typeof(MyHyperLinkBehavior), new PropertyMetadata(default(string)));
        void AssociatedObject_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Changing "GetValue(SalutationProperty)" to "this.AssociatedObject.GetValue(SalutationProperty)" works
            MessageBox.Show(Convert.ToString(this.AssociatedObject.GetValue(SalutationProperty)));
        }
    }
