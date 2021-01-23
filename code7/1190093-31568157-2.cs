       public sealed class MainVm : DependencyObject
        {
           public static readonly DependencyProperty IsGreenProperty =
               DependencyProperty.Register("IsGreen", typeof (bool), typeof (MainVm), new PropertyMetadata(default(bool)));
    
           public bool IsGreen
            {
               get { return (bool) GetValue(IsGreenProperty); }
               set { SetValue(IsGreenProperty,value); }
            }
        }
