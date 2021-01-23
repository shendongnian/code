    public partial class Form1 : Form
    {
        TypeAssistant assistant;
        public Form1()
        {
            InitializeComponent();
            assistant = new TypeAssistant();
            assistant.Idled += assistant_Idled;          
        }
        void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
            new MethodInvoker(() =>
            {
                // do your job here
            }));
        }
        private void yourFastReactingTextBox_TextChanged(object sender, EventArgs e)
        {
            assistant.TextChanged();
        }
    }
