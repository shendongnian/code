    using System;
    using System.Windows;
    using System.Windows.Controls;
    namespace ScrollViewer
    {
        public partial class MainWindow : Window
        {
            public MainWindow ()
            {
                InitializeComponent ();
                SV.ScrollChanged += ScrollChangedEventHandler;
            }
            bool firstScrollAfterContenChanged;
            private void Button_Click (object sender, RoutedEventArgs e)
            {
                firstScrollAfterContenChanged = true;
                SVContent.Height = 1000;
            }
            public void ScrollChangedEventHandler(Object sender, ScrollChangedEventArgs e)
            {
                if (firstScrollAfterContenChanged)
                {
                    firstScrollAfterContenChanged = false;
                    SV.ScrollToVerticalOffset (SV.ScrollableHeight / 2);
                }
            }
        }
    }
