    using UnityEngine;
    using System.Collections;
    namespace WpfApplication5
    {
        public partial class Window2 : Window
        {
            // You must implement your own MyScriptClass that has MonoBehaviour as it's
            // base class and provide an appropriate constructor to use here, in the
            // Window2 constructor or some other appropriate location.
            private MonoBehaviour _monoBehaviour = new MyScriptClass();
            // Default constructor
            public Window2()
            {
                // Set up your _monoBehaviour here
                // Initialise the WPF Window GUI object
                InitializeComponent();
            }
            // Called by the WPF FrameworkElement.Loaded Event
            public void event_rotate(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("asdasada");
            }
        }
    }
