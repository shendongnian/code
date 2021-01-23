    /// <summary>
    /// Displays an OK and Cancel button. When one is pressed, 
    /// the dialog is closed and a message box is displayed.
    /// The actual value of the property is unchanged throughout.
    /// </summary>
    /// <remarks>The ToolboxItem attribute prevents the control from being displayed in the ToolKit.</remarks>
    [ToolboxItem(false)]
    public partial class SimpleTest : UserControl
    {
        public bool Cancelled { get; set; }
        private IWindowsFormsEditorService m_EditorService;
        // Require the use of the desired overloaded constructor.
        private SimpleTest()
        {
            InitializeComponent();
        }
        internal SimpleTest(IWindowsFormsEditorService editorService)
            : this()
        {
            // Cache the editor service.
            m_EditorService = editorService;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Cancelled = false;
            m_EditorService.CloseDropDown();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            m_EditorService.CloseDropDown();
        }
    }
