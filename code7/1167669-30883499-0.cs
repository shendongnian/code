    public partial class YourFormClass: Form
    {
        private static YourFormClass mInst;
        private YourFormClass()
        {
            InitializeComponent();
        }
        public static YourFormClass CheckInst
        {
            get
            {
                return mInst;
            }
        }
        public static YourFormClass CreateInst
        {
            get
            {
                if (mInst == null)
                    mInst = new YourFormClass();
                return mInst;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            mInst = null;
            base.OnClosed(e);
        }
    }
