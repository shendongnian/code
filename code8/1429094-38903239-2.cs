    using System.Windows.Forms;
    //Note: if you create a new class by clicking PROJECT->Add Windows Form,
    //then this class definition and the constructor are automatically created for you.
    //Open MyFancyForm.cs, right click on the form, and click View Code to see it.
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
