    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
_____________
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // The first element in the array contains the file name of the executing program. 
            // If the file name is not available, the first element is equal to String.Empty. 
            // The remaining elements contain any additional tokens entered on the command line. 
            var args = Environment.GetCommandLineArgs()[0];
            var path = (args.Count == 1) ? args[0] : args[1];
            if (path == string.Empty)
            {
                MessageBox.Show("No file path found.");
            }
            else
            {
                MessageBox.Show("File path found!");
            }
        }
    }
