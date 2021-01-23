    public partial class TextBoxMaterial : UserControl
    {
        public TextBoxMaterial()
        {
            InitializeComponent();
            this.Controls.Add(new Label()
            {
                Height = 2,
                Dock = DockStyle.Bottom,
                BackColor = Color.Gray,
            });
            this.Controls.Add(new TextBox()
            {
                Left = 10,
                Width = this.Width - 20,
                BackColor = this.BackColor,
                BorderStyle = BorderStyle.None,
             });
        }
    }
