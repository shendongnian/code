            public Form1()
            {
                InitializeComponent();
            }
            public delegate void SendMessage(string Firstname, string Lastname,string Pay);
    	    public event SendMessage OnSendMessage;
            private void button1_Click(object sender, EventArgs e)
            {
                Form3 from3 = new Form3();
                OnSendMessage += from3.Message;
                OnSendMessage(Firstname.Text, Lastname.Text, Pay.Text);
                from3.Show(); 
            }
