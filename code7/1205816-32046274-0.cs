    public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
    
                this.IsVisibleChanged += UserControl1_IsVisibleChanged;
            }
    
            void UserControl1_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {         
               txt.Focus();
             //txt is the name of the TextBox which is to be focused
            }
        }
