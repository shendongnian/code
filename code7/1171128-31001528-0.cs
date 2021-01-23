    public class BaseMetroDialogAdjustTextBehavior : Behavior<InputDialog>
    {
        public static DependencyProperty IsAttachedProperty =
                       DependencyProperty.RegisterAttached("IsAttached", 
                       typeof(bool),
                       typeof(BaseMetroDialogAdjustTextBehavior),
                       new FrameworkPropertyMetadata(false, OnIsAttachedChanged));
        private TextBox inputTextBox;
        public static bool GetIsAttached(DependencyObject uie)
        {
            return (bool)uie.GetValue(IsAttachedProperty);
        }
 
        public static void SetIsAttached(DependencyObject uie, bool value)
        {
            uie.SetValue(IsAttachedProperty, value);
        }
        private static void OnIsAttachedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = obj as UIElement;
            if (element == null)
               return;
            {
                var behaviors = Interaction.GetBehaviors(element);
                var existingBehavior = behaviors.OfType<BaseMetroDialogAdjustTextBehavior>().FirstOrDefault();
                
                if ((bool)e.NewValue == false && existingBehavior != null)
                {
                    behaviors.Remove(existingBehavior);
                }
                else if ((bool)e.NewValue == true && existingBehavior == null)
                {
                    behaviors.Add(new BaseMetroDialogAdjustTextBehavior());
                }
            }
        }
        protected override void OnAttached()
        {
            inputTextBox = AssociatedObject.FindName("PART_TextBox") as TextBox;
            inputTextBox.GotFocus += inputTextBox_GotFocus;
        }
        protected override void OnDetaching()
        {
            inputTextBox.GotFocus += inputTextBox_GotFocus;
        }
        void inputTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            inputTextBox.CaretIndex = inputTextBox.Text.Length;
        }
    }
