    `public partial class Window1 : Window
    {
    public Window1()
    {
        InitializeComponent();
    }
    private void details_Load(object sender, EventArgs e)
    {
        Fname.Text = MainWindow.Student.sFname;
        Sname.Text = Mainwindow.Student.sSname;
    }
    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
    }`
