    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MethodInfo miHandler = typeof(Form1).GetMethod("DiagnosticHandler", BindingFlags.NonPublic | BindingFlags.Instance);
            EventInfo[] events = typeof(TextBox).GetEvents();
            foreach (EventInfo ei in events)
            {
                Type tDelegate = ei.EventHandlerType;
                Delegate d = Delegate.CreateDelegate(tDelegate, this, miHandler);
                MethodInfo addHandler = ei.GetAddMethod();
                Object[] addHandlerArgs = { d };
                addHandler.Invoke(this.textBox1, addHandlerArgs);
            }
        }
        private void DiagnosticHandler(object sender, EventArgs e)
        {
            //whatever
        }
    }
