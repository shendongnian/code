    namespace MyProject.Controls
    {
        public partial class TestControl : UserControl
        {
            //Register Dependency Property
    
            public static readonly DependencyProperty TestMeDependency = DependencyProperty.Register("MyProperty", typeof(string), typeof(TestControl));
    
            public string MyCar
            {
                get
                {
    
                    return (string)GetValue(TestMeDependency);
    
                }
                set
                {
                    SetValue(TestMeDependency, value);
                }
            }
    
            public TestControl()
            {
                InitializeComponent();
            }
        }
    }
