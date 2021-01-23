    public class CustomComboBox : ComboBox
    {
        private int _selected;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _selected = SelectedIndex;
            SelectedIndex = -1;
            Loaded += ComboBoxEx_Loaded;
        }
        void ComboBoxEx_Loaded(object sender, RoutedEventArgs e)
        {
            var popup = GetTemplateChild("PART_Popup") as Popup;
            var content = popup.Child as FrameworkElement;
            content.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            MinWidth = content.DesiredSize.Width;
            SelectedIndex = _selected;
        }
    }
