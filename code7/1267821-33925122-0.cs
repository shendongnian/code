    /// <summary>
    /// Form with "skeleton" common for your application.
    /// </summary>
    public partial class FormWithPicture : Form {
        private Control content;
        /// <summary>
        /// The control which should be used as "main" content of this form.
        /// </summary>
        public Control Content {
            get { return this.content; }
            set {
                this.content = value;
                // the "panel1" is the container of the content
                this.panel1.Controls.Clear();
                if (null != value) {
                    this.panel1.Controls.Add(value);
                }
            }
        }
        public FormWithPicture() {
            InitializeComponent();
        }
    }
    // somewhere else
    new FormWithPicture {
        Content = new ContentControl_A()
    }.Show();
