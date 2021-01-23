     public class ViewModel: DependencyObject
     {
                public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
                    "Type", typeof (string), typeof (ViewModel), new PropertyMetadata(default(string)));
                public int Type
                {
                    get { return (int) GetValue(TypeProperty ); }
                    set { SetValue(TypeProperty , value); }
                }
     }
