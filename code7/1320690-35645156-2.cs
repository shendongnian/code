    /// <summary>
    /// ToolStripSplitCheckButton adds a Check property to a ToolStripSplitButton.
    /// </summary>
    public partial class ToolStripSplitCheckButton : ToolStripSplitButton
    {
        //==============================================================================
        // Inner class: ToolBarButonSplitCheckButtonEventArgs
        //==============================================================================
    
        /// <summary>
        /// The event args for the check button click event. To be able to use the OnCheckedChanged
        /// event, we must also record a dummy button as well as this one (hack).
        /// </summary>
        public class ToolBarButonSplitCheckButtonEventArgs : ToolBarButtonClickEventArgs
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="split_button">The sender split check button</param>
            public ToolBarButonSplitCheckButtonEventArgs(ToolStripSplitCheckButton split_button)
                : base(new ToolBarButton("Dummy Button"))       // Hack - Dummy Button is not used
            {
                SplitCheckButton = split_button;
            }
    
            /// <summary>
            /// The ToolStripSplitCheckButton to be sent as an argument.
            /// </summary>
            public ToolStripSplitCheckButton SplitCheckButton { get; set; }
        }
    
    
        //==========================================================================
        // Construction
    
        public ToolStripSplitCheckButton()
        {
            m_checked = false;
            m_mouse_over = false;
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
            if (CheckOnClick) {
                m_checked = !m_checked;
                // Raise the OnCheckStateChanged event when the button is clicked
                if (OnCheckChanged != null) {
                    ToolBarButonSplitCheckButtonEventArgs args = new ToolBarButonSplitCheckButtonEventArgs(this);
                    OnCheckChanged(this, args);
                }
            }
            base.OnButtonClick(e);
        }
    
        /// <summary>
        /// On mouse enter, record that we are over the button.
        /// </summary>
        protected override void OnMouseEnter(EventArgs e)
        {
            m_mouse_over = true;
            base.OnMouseEnter(e);
            this.Invalidate();
        }
    
        /// <summary>
        /// On mouse leave, record that we are no longer over the button.
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            m_mouse_over = false;
            base.OnMouseLeave(e);
            this.Invalidate();
        }
    
        /// <summary>
        /// Paint the check highlight when required.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (m_checked) {
                // I can't get the check + mouse over to render properly, so just give the button a colour fill - Hack
                if (m_mouse_over) {
                    using (Brush brush = new SolidBrush(Color.FromArgb(64, SystemColors.MenuHighlight))) {
                        e.Graphics.FillRectangle(brush, ButtonBounds);
                    }
                }
                ControlPaint.DrawBorder(
                    e.Graphics,
                    e.ClipRectangle,            // To draw around the button + drop-down
                    //this.ButtonBounds,        // To draw only around the button 
                    SystemColors.MenuHighlight,
                    ButtonBorderStyle.Solid);
            }
        }
    
    
        //==========================================================================
        // Member Variables
    
        // The delegate that acts as a signature for the function that is ultimately called 
        // when the OnCheckChanged event is triggered.
        public delegate void SplitCheckButtonEventHandler(object source, EventArgs e);
        public event SplitCheckButtonEventHandler OnCheckChanged;
    
        private bool m_checked;
        private bool m_mouse_over;
    }
