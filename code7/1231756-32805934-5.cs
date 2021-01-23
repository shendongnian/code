    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace Windamow
    {
        /// <summary>
        /// Interaction logic for Win32803621.xaml
        /// </summary>
        public partial class Win32803621 : Window
        {
            public Win32803621()
            {
                InitializeComponent();
                tbHtmlInput.Text = "<a href='http://www.stackoverflow.com'>Click to open StackOverflow.com</a>";
            }
    
            DynamoWindow browserWindow;
    
            private void btnCreateAndOpen_Click(object sender, RoutedEventArgs e)
            {
                Windamow.MakeWindow(true, tbHtmlInput.Text);
            }
    
            private void btnUpdateBrowser_Click(object sender, RoutedEventArgs e)
            {
                browserWindow = Windamow.window;
                browserWindow.ReportPage = tbHtmlInput.Text;
            }
        }
    }
