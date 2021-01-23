    public partial class MyForm : Form, ITabControlProvider
    {
        ...
        TabControl MainTabControl { get { return tabControl1; } }
    }
