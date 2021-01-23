    //First make a reference to skype4com, probably in here: C:\Program Files (x86)\Common Files\Skype
    //Then use the following code:
    using System;
    using System.Windows.Forms;
    using SKYPE4COMLib;
    
    namespace Skype
    {
        public partial class Form1 : Form
        {
            private SKYPE4COMLib.Skype skype;
    
            public Form1()
            {
                InitializeComponent();
                skype = new SKYPE4COMLib.Skype();
                skype.Attach(7, false);
                skype.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(skype_MessageStatus);
            }
    
            private void skype_MessageStatus(ChatMessage msg, TChatMessageStatus status)
            {
                string message = msg.Sender + ": " + msg.Body;
                listBox1.Items.Add(message);
            }
        }
    }
