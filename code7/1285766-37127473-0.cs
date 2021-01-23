    using System;
    using System.Windows.Forms;
    using SKYPE4COMLib;
    
    namespace Italics
    {
        public partial class Form1 : Form
        {
            Skype skype;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                skype = new Skype();
                skype.Attach(7, true);
                skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);
            }
    
            private void skype_MessageStatus(ChatMessage msg, TChatMessageStatus status)
            {
                msg.Body = "_" + msg.Body + "_";
            }
        }
    }
