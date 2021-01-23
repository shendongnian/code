    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            label1.Text = Servers.GetTextForLabel();
        }
    }
    public class Servers
    {
        public static string GetTextForLabel()
        {
           return "New Text"; //(I assume this will be much more complex)
        }
    }
