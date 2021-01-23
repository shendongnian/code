    //New
    public delegate void SendTextUC(string YourStringInTextBox);
    public partial class UserControl1 : UserControl
    {
        //New
        public event SendTextUC UISendTextHandlerUC;
        public UserControl1(TextBox r)
        {
            InitializeComponent();
            this.r = r;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(r);
            frm2.Show();
            //Add event handler
            frm2.UISendTextHandlerF2 += SendText123;
        }
        //Event Handler for the event trigger in Form2
        void SendText123(string YourStringFromTextBox)
        {
            //Trigger Event
            if(UISendTextHandlerUC!=null)
                UISendTextHandlerUC(YourStringFromTextBox);
        }
    }
