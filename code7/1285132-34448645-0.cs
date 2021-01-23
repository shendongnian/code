    using SendFileTo;
    
    namespace TestSendTo
    {
        public partial class Form1 : Form
        {
            private void btnSend_Click(object sender, EventArgs e)
            {
                MAPI mapi = new MAPI();
    
                mapi.AddAttachment("c:\\temp\\file1.txt");
                mapi.AddAttachment("c:\\temp\\file2.txt");
                mapi.AddRecipientTo("person1@somewhere.com");
                mapi.AddRecipientTo("person2@somewhere.com");
                mapi.SendMailPopup("testing", "body text");
                
                // Or if you want try and do a direct send without displaying the 
                // mail dialog mapi.SendMailDirect("testing", "body text");
            }
        }
    }
