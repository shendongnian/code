    public partial class MainWindow
    {
        bool mCausedByCode = false;
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void UIElement_OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            Debug.WriteLine(e.DeltaManipulation.Translation.X);
            if(!mCausedByCode)
            {
                Left += e.DeltaManipulation.Translation.X;
                mCausedByCode = true;
            }
            else
            {
                mCausedByCode = false;
            }
            e.Handled = true;
        }
    }
