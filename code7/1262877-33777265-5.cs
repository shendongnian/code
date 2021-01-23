    public partial class Form1 : Form
    {
        TypeAssistant assistant;
        public Form1()
        {
            InitializeComponent();
            asssitant = new TypeAssistant(600);
            asssitant.Idled += asssitant_Idled;          
        }
        void assistant_Idled(object sender, EventArgs e)
        {
            this.Invoke(
                new MethodInvoker(()=>{ // do your job here}));
        }
        private void yourFastReactingTextBox_TextChanged(object sender, EventArgs e)
        {
            assistant.TextChanged();
        }
    }
