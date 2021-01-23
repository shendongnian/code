     public class MyUserControl : Control{
        
        public string MyControlsText
        {
            get { return (string)GetValue(MyControlsTextProperty); }
            set { SetValue(MyControlsTextProperty, value); }
        }
        
        public static readonly DependencyProperty MyControlsTextProperty = 
                 DependencyProperty.Register("MyControlsText", typeof(string), 
                    typeof(MyUserControl), new PropertyMetadata(String.Empty)); 
        
        }
