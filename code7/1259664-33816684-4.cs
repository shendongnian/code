    using System;
    using System.Globalization;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace DocViewerLoc
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                CultureChanger = new SimpleCommand(ChangeCulture);
                InitializeComponent();
            }
    
            /// <summary>
            ///  ChangeCulture is called when one of the buttons with caption 
            /// 'en-us' or 'de-DE' is pressed. 
            /// </summary>
            /// <param name="parameter">
            /// A string containing the caption 'en-us' or 'de-DE'. 
            /// </param>
            private void ChangeCulture(object parameter)
            {
                string ietfLanguageTag = parameter as string;
                if (ietfLanguageTag == null) return;
    
                var cultureInfo = CultureInfo.GetCultureInfo(ietfLanguageTag);
    
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
    
                // This will ensure that CultureAwareDocumentViewer's Language property
                // binds to the updated value set here when it is instantiated next.
                UILanguage = ietfLanguageTag;
    
                // Remove the old instance of _documentViewer from the UI. 
                var parent = VisualTreeHelper.GetParent(_documentViewer) as Grid;
                int index = parent.Children.IndexOf(_documentViewer);
                parent.Children.Remove(_documentViewer);
    
                // Create a new instance of CultureAwareDocumentViewer. This will 
                // use the updated value of UILanguage bind it to its Language (xml:lang)
                // property, thus resulting in the appropriate language resources being 
                // loaded. 
                _documentViewer = new LocalizedDocumentViewer.CultureAwareDocumentViewer();
    
                // Now, add the _documentViewer instance back to the UI tree. 
                parent.Children.Add(_documentViewer);
            }
    
            /// <summary>
            /// ICommand used to bind to en-us and de-DE buttons in the UI
            /// </summary>
            #region CultureChange
            public SimpleCommand CultureChanger
            {
                get { return (SimpleCommand)GetValue(CultureChangerProperty); }
                set { SetValue(CultureChangerProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for CultureChanger.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty CultureChangerProperty =
                DependencyProperty.Register("CultureChanger", typeof(SimpleCommand), typeof(MainWindow), new PropertyMetadata(default(SimpleCommand)));
    
            #endregion
    
            /// <summary>
            /// UILanguage property used to bind to the FrameworkElement.Language (xml:lang) property
            /// in the DocumentViewer object within the CultureAwareDocumentViewer control. 
            /// </summary>
            #region UILanguage
    
            public string UILanguage
            {
                get { return (string)GetValue(UILanguageProperty); }
                set { SetValue(UILanguageProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for UILanguage.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty UILanguageProperty =
                DependencyProperty.Register("UILanguage", typeof(string), typeof(MainWindow), new PropertyMetadata(Thread.CurrentThread.CurrentUICulture.IetfLanguageTag));
    
            #endregion
        }
    
        /// <summary>
        /// Simple implementation of the ICommand interface that delegates 
        /// Execute() to an Action<object>. 
        /// </summary>
        public class SimpleCommand : ICommand
        {
    #pragma warning disable 67 
            public event EventHandler CanExecuteChanged;
    #pragma warning restore 67 
            public SimpleCommand(Action<object> handler)
            {
                _handler = handler;
            }
    
            public bool CanExecute(object parameter)
            {
                return true;
            }
    
            public void Execute(object parameter)
            {
                _handler?.Invoke(parameter);
            }
    
            private Action<object> _handler;
        }
    }
