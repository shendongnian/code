    public Form1() {
        InitializeComponent();
        var panels = 8;
        var size = 20;
        var on = Color.Yellow;
        var off = Color.Black;
        for (int i = 0; i < panels; i++) {
            for (int j = 0; j < panels; j++) {
                var panel = new Panel() {
                    Left = i * size, Top = j * size,
                    Width = size, Height = size, BackColor = off
                };
                panel.MouseDown += (s, ea) => {
                    panel.BackColor = panel.BackColor == on ? off : on;
                    panel.Capture = false;
                };
                panel.MouseMove += (s, ea) => {
                    if (ea.Button == MouseButtons.Left) panel.BackColor = Color.Yellow;
                };
                this.Controls.Add(panel);
            }
        }
    }
