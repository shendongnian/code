    public partial class MainPage
    {
        private CallBack CallBackDelegate = new CallBack(CallBackFunction);
        public MainPage()
        {
            InitializeComponent();
        }
        public delegate void CallBack([In][MarshalAs(UnmanagedType.LPStr)] string strParam);
        [DllImport("Test.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void PerformActionWithCallBack(int x);
        void DemonstrateCallBack()
        {
            int x;
            
            // Converting callback_delegate into a function pointer that can be
            // used in unmanaged code.
            IntPtr intptr_delegate = Marshal.GetFunctionPointerForDelegate(CallBackDelegate);
            //Getting the pointer into integer value and sending it to C++
            x = (int)intptr_delegate;
            testApp.PerformActionWithCallBack(x);
        }
        //CallBack function in which event messages will be received
        void CallBackFunction([In][MarshalAs(UnmanagedType.LPStr)] string strParam)
        {
            if (Dispatcher.CheckAccess() == false)
            {
                //Updating the text block with the received message
                Dispatcher.BeginInvoke(() => MyTextBlock.Text = strParam);
            }
            else
            {
                MyTextBlock.Text = "Update directly";
            }
        }
    }
