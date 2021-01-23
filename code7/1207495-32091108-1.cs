    namespace AppWpf10
    {
        public partial class Prepare : System.Windows.Controls.Page
        {
            private void button_Click(object sender, RoutedEventArgs e)
            {
                Choice win2 = new Choice();
                win2.Show();
                win2.button1.Click += clickEventHandler;
            }
            private void clickEventHandler(object sender, RoutedEventArgs e)
            {
                DoStuff();
            }
            public void DoStuff()
            {
                //
            }
        }
    }
