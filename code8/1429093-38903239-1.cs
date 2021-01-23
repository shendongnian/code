    using System.Windows.Forms;
    public partial class MyFancyForm : Form
    {
        public MyFancyForm()
        {
            InitializeComponent();
        }
    }
    static void Main(string[] args)
    {
         var guiForm = new MyFancyForm();
         guiForm.ShowDialog();//This "opens" the GUI on your screen
    }
