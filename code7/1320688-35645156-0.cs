    {
    /// <summary>
    /// ToolStripSplitCheckButton adds a Check property to a ToolStripSplitButton.
    /// </summary>
    public partial class ToolStripSplitCheckButton : ToolStripSplitButton
    {
        //==========================================================================
        // Construction
    
        public ToolStripSplitCheckButton()
        {
            InitializeComponent();
            m_checked = false;
        }
        
        
        //==========================================================================
        // Properties
    
        /// <summary>
        /// Indicates whether the button should toggle its Checked state on click.
        /// </summary>
        [Category("Behavior"), 
        Description("Indicates whether the item should toggle its selected state when clicked."), 
        DefaultValue(true)]
        public bool CheckOnClick { get; set; }
    
        /// <summary>
        /// Indictates the Checked state of the button.
        /// </summary>
        [Category("Behavior"), 
        Description("Indicates whether the ToolStripSplitCheckButton is pressed in or not pressed in."), 
        DefaultValue(false)]
        public bool Checked { get { return m_checked; } set { m_checked = value; } }
    
    
        //==========================================================================
        // Methods
    
        /// <summary>
        /// Toggle the click state on button click.
        /// </summary>
        protected override void OnButtonClick(EventArgs e)
        {
            base.OnButtonClick(e);
            if (CheckOnClick) m_checked = !m_checked;
        }
    
        /// <summary>
        /// Paint the check highlight when required.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (m_checked) {
                ControlPaint.DrawBorder(
                    e.Graphics,
                    e.ClipRectangle,
                    SystemColors.MenuHighlight, 
                    ButtonBorderStyle.Solid);
            }
        }
    
    
        //==========================================================================
        // Member Variables
    
        private bool m_checked;
    }
