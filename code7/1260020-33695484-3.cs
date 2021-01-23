    [TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
    [TemplatePart(Name = "PART_Button", Type = typeof(Button))]
    public class CustomControl1 : Control
    {
        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
        }
        public CustomControl1()
        {
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var button = GetTemplateChild("PART_Button") as Button;
            if (button != null)
            {
                button.Click += Button_Click;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var textBox = GetTemplateChild("PART_TextBox") as TextBox;
            if (textBox != null)
            {
                textBox.Text = "HI!";
            }
        }
    }
