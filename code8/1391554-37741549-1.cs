    public partial class Form1 : Form
    {
        public Form1()
        {
            //InitializeComponent();
        }
        #region Silent mode
        private static Form1 _instance;
        /// <summary>
        /// Prevent window getting visible
        /// </summary>
        /// <param name="value"></param>
        protected override void SetVisibleCore(bool value)
        {
            // Prevent window getting visible            
            CreateHandle();
            _instance = this;
            //do not show the window
            value = false;
            base.SetVisibleCore(value);
        }
        #endregion
    }
