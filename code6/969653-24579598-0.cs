    public partial class ThisAddIn
    {
        private Inspectors _inspectors;
        private List<MailItem> _mailItems = new List<MailItem>();
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _inspectors = Application.Inspectors;
            _inspectors.NewInspector += Inspectors_NewInspector;
        }
    
        void Inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            Outlook.MailItem mailItem = Inspector.CurrentItem as Outlook.MailItem;
            if (mailItem != null)
            {
                if (mailItem.EntryID == null)
                {
                    _mailItems.Add(mailItem):
                    mailItem.BeforeAttachmentAdd += mailItem_BeforeAttachmentAdd;
                    //System.Windows.Forms.MessageBox.Show("Twice");
                }
            }
        }
    
        void mailItem_BeforeAttachmentAdd(Outlook.Attachment Attachment, ref bool Cancel)
        {
            Cancel = true;
        }
    
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
