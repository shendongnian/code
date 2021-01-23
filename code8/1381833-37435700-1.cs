    public partial class usr1: UserControl
       {
          public usr1()
          {
             InitializeComponent();
          }
    
          public static readonly DependencyProperty MyCheckboxIsCheckedProperty = DependencyProperty.Register(
           "MyCheckboxIsChecked", typeof(bool), typeof(usr1), new PropertyMetadata(default(bool)));
    
          public bool MyCheckboxIsChecked
          {
             get
             {
                return (bool)GetValue(MyCheckboxIsCheckedProperty);
             }
             set
             {
                SetValue(MyCheckboxIsCheckedProperty, value);
             }
          }
       }
