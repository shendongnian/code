    public class ScreenLogging
    {
        private static ScreenLogging _instance;
        private ScreenLogging() { }
        public static ScreenLogging Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScreenLogging();
                }
                return _instance;
            }
        }
        private TextBox _target;
        public static void SetTarget(TextBox target)
        {
            Instance._target = target;
        }
        public static void Write(string content, LoggingLevel warningLevel)
        {
            var appendTextAction = new Action(() =>
            {
                var text = warningLevel.ToString() + ": " + content + "\n";
                Instance._target.AppendText(text);
            });
            // Only the thread that the Dispatcher was created on may access the
            // DispatcherObject directly. To access a DispatcherObject from a 
            // thread other than the thread the DispatcherObject was created on,
            // call Invoke and BeginInvoke on the Dispatcher the DispatcherObject 
            // is associated with.
            // You can set the priority to Background, so you guarantee that your
            // key operations will be processed first, and the screen updating 
            // operations will happen only after those operations are done.
            Instance._target.Dispatcher.Invoke(appendTextAction, 
                DispatcherPriority.Background);
        }
    }
