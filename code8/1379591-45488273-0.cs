      public class ValidatingTextBox : TextBox
      {
        public ValidatingTextBox()
        {
          // Tells this control to use the ValidatingTextBox style. 
          // This will be the customized textbox style below. 
          this.DefaultStyleKey = typeof(ValidatingTextBox);
        }
    
        public bool HasError
        {
          get { return (bool)GetValue(HasErrorProperty); }
          set { SetValue(HasErrorProperty, value); }
        }
    
        /// <summary>
        /// This is a dependency property that will indicate if there's an error. 
        /// This DP can be bound to a property of the VM.
        /// </summary>
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(ValidatingTextBox), new PropertyMetadata(false, HasErrorUpdated));
    
    
        // This method will update the Validation visual state which will be defined later in the Style
        private static void HasErrorUpdated(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
          ValidatingTextBox textBox = d as ValidatingTextBox;
    
          if (textBox != null)
          {
            if (textBox.HasError)
              VisualStateManager.GoToState(textBox, "InvalidState", false);
            else
              VisualStateManager.GoToState(textBox, "ValidState", false);
          }
        }
      }
