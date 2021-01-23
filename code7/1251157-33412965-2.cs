     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                var control = new myUserControl();
                myPersons = new List<Person>() { new Person() { Name = "some" } };
                control.SetBinding(myUserControl.MyPropertyProperty, new Binding() { Source = MyPersons });
            }
    
            private List<Person> myPersons { get; set; }
            public List<Person> MyPersons { get { return myPersons; } set { myPersons = value; } }
        }
    
        public class Person { public string Name; }
    
        public class myUserControl : UserControl
        {
            public object MyProperty
            {
                get { return (object)GetValue(MyPropertyProperty); }
                set { SetValue(MyPropertyProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty MyPropertyProperty =
                DependencyProperty.Register("MyProperty", typeof(object), typeof(myUserControl), new PropertyMetadata(0));
        }
