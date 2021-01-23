    namespace WordAddIn
    {        
        public partial class WpfControl : UserControl
        {
            // your code
            private DispatcherFrame dispatcherFrame;           
    
            private object DispatcherOperationBegin(object arg)
            {
                dispatcherFrame = new DispatcherFrame();
                Dispatcher.PushFrame(dispatcherFrame);
                return null;
            }
    
            private void ComboBox_OnDropDownOpened(object sender, EventArgs e)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new DispatcherOperationCallback(DispatcherOperationBegin), null);
            }
    
            private void ComboBox_OnDropDownClosed(object sender, EventArgs e)
            {
                dispatcherFrame.Continue = false;
            }
        }
    }
