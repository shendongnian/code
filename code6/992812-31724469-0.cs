    public partial class ImportForm : DockContent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportForm" /> class.
        /// Constructor for non modal import control window
        /// </summary>
        /// <param name="guiLogic">The GUI logic.</param>
        public ImportForm(GuiLogic guiLogic)
        {
            InitializeComponent();
            this.MinimumSize = new Size(400, 400);
            this.Resize += new EventHandler(ResizeEvent);
        }
        // If the content won't display nicely, hide it
        private void ResizeEvent(object sender, EventArgs e)
        {
            this.Visible = this.Width > this.MinimumSize.Width && this.Height > this.MinimumSize.Height;
        }
    }
