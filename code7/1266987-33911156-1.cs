    using System;
    using System.Windows;
    using System.Windows.Input;
    
    namespace CommandsSample
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            #region NewFileCommand Handlers
    
            /// <summary>
            /// CanExecute
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void CouldCreateNewFile(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = !string.IsNullOrEmpty(FileText);
            }
    
            /// <summary>
            /// Executed
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void CreatenewFile(object sender, ExecutedRoutedEventArgs e)
            {
                FileText = string.Empty;
            }
    
            #endregion NewFileCommand Handlers
    
            #region Dependency Properties 
    
            /// <summary>
            /// The contents of the TextBox in the UI are backed by this property
            /// </summary>
            public String FileText
            {
                get { return (String)GetValue(FileTextProperty); }
                set { SetValue(FileTextProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for FileText.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty FileTextProperty =
                DependencyProperty.Register("FileText", typeof(String), typeof(MainWindow), new PropertyMetadata(string.Empty));
    
    
            #endregion Dependency Properties
        }
    }
