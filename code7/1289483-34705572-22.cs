    public class ItemsSourcePosessingBehavior : Behavior<ComboBox>
    {
        public static readonly DependencyProperty SiblingComboBoxProperty = DependencyProperty.Register(
            "SiblingComboBox", typeof(ComboBox), typeof(ItemsSourcePosessingBehavior), new PropertyMetadata(default(ComboBox)));
        public ComboBox SiblingComboBox
        {
            get { return (ComboBox)GetValue(SiblingComboBoxProperty); }
            set { SetValue(SiblingComboBoxProperty, value); }
        }
        public static readonly DependencyProperty SourceProvidingFactoryProperty = DependencyProperty.Register(
            "SourceProvidingFactory", typeof (SourceProvidingFactory), typeof (ItemsSourcePosessingBehavior), new PropertyMetadata(default(SourceProvidingFactory)));
        public SourceProvidingFactory SourceProvidingFactory
        {
            get { return (SourceProvidingFactory) GetValue(SourceProvidingFactoryProperty); }
            set { SetValue(SourceProvidingFactoryProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            SiblingComboBox.SelectionChanged += SiblingComboBoxOnSelectionChanged;
        }
        private void SiblingComboBoxOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            AssociatedObject.ItemsSource = null;
            var siblingCombo = sender as ComboBox;
            if (siblingCombo == null)
            {
                return;
            }
            if (SourceProvidingFactory == null)
            {
                return;
            }
            AssociatedObject.ItemsSource = SourceProvidingFactory.GetCollection(siblingCombo.SelectedItem);
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            SiblingComboBox.SelectionChanged -= SiblingComboBoxOnSelectionChanged;
        }
    }
