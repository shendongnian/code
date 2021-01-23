    public class NumericUpDown : Control
    {
        static NumericUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), 
                new FrameworkPropertyMetadata(typeof(NumericUpDown)));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button increaseButton = this.GetTemplateChild("increaseButton") as Button;
            if (increaseButton != null)
            {
                increaseButton.Click += increaseButton_Click;
            }
        }
        private void increaseButton_Click(object sender, RoutedEventArgs e)
        {
            // Do what you want to do.
        }
    }
