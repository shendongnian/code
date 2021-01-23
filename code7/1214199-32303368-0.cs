    public class MyQuickFixApp : QuickFix.IApplication
    {
        private readonly Form1 _form1;
        public MyQuickFixApp(Form1 form)
        {
           _form1 = form;
        }
        public void FromAdmin(QuickFix.Message msg, SessionID sessionID) 
        {
            _form1.logListView.Items.Add(msg.ToString());
        }
    }
