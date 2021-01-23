    public UserControl1()
    {
        InitializeComponent();
        var menu = new MenuStrip();
        var item = new ToolStripMenuItem();
        item.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C;
        item.Click += item_Click;
        menu.Items.Add(item);
        menu.Visible = false;
        this.Controls.Add(menu);
    }
    void item_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Ctrl + C");
    }
