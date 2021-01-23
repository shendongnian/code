    using System.Windows;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for Test.xaml
        /// </summary>
        public partial class Test : Window
        {
            public Test()
            {
                InitializeComponent();
                
            }
        }
    }
    
    namespace MyNameSpace
    {
        public static class MyClass
        {
            static MyClass()
            {
                MyField = "Testing";
            }
            public static string MyField {get; set;}
        }
    }  
