    public class LocalizedDocumentViewer : DocumentViewer
    {
        public LocalizedDocumentViewer()
        {
            Loaded += new RoutedEventHandler(OnLoaded);
        }
    
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Button button = FindChild<Button>(this, "PrintButton");
            button.ToolTip = Properties.Resources.PrintToolTip;
    
            button = FindChild<Button>(this, "CopyButton");
            button.ToolTip = Properties.Resources.CopyToolTip;
    
            button = FindChild<Button>(this, "FindPreviousButton");
            button.ToolTip = Properties.Resources.FindPreviousToolTip;
    
            button = FindChild<Button>(this, "FindNextButton");
            button.ToolTip = Properties.Resources.FindNextToolTip;
    
            Label label = FindChild<Label>(this, "FindTextLabel");
            label.Content = Properties.Resources.FindTextLabel;
    
            /* and so on... */
        }
    
        public static T FindChild<T>(DependencyObject parent, string childName)
            where T : DependencyObject
        {
            /* see the link for the code */
        }
    }
