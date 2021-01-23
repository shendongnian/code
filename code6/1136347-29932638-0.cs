    public abstract class SomeUserControl : UserControl 
    {
       //declared by XAML (can be made public with x:FieldModifier="public")
       public Button MyButton;
       //code-behind 
       public SomeUserControl() {
           InitializeComponent();
       }     
    }
    public class MySpecialControl : SomeUserControl {
          public MySpecialControl() {
             MyButton.Click += (sender, e) => MessageBox.Show("Bla");
          }      
    }
