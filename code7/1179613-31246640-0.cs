      public partial class Form1 : Form
        {
            SMSCOMMS SMSEngine;
          
            public Form1()
            {
               
                        SMSEngine = new SMSCOMMS("COM1");
           
           
     
                InitializeComponent();
                SMSEngine.Open();
            }
     
            private void button1_Click(object sender, EventArgs e)
            {
              SMSEngine.SendSMS("919888888888","THIS IS YOUR MESSAGE");
              SMSEngine.Close();
            }
        }
    }
