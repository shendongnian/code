    namespace VBEAddIn
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Call_VBA("Test");
            }
    
            private void Call_VBA(string p_Procedure)
            {
                var olApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Core.CommandBars mObj_of_CommandBars;
    
                Microsoft.Office.Core.CommandBars mObj_of_CommandBars = new Microsoft.Office.Core.CommandBars();
                Microsoft.Office.Interop.Outlook.Explorer mObj_ou_Explorer;
                Microsoft.Office.Interop.Outlook.MailItem mObj_ou_MailItem;
                Microsoft.Office.Interop.Outlook.UserProperty mObj_ou_UserProperty;
    
                //mObj_ou_Explorer = Globals.Menu_AddIn.Application.ActiveExplorer
                mObj_ou_Explorer = olApp.ActiveExplorer();
    
                //I want this to run only when one item is selected
                if (mObj_ou_Explorer.Selection.Count == 1)
                {
                    mObj_ou_MailItem = mObj_ou_Explorer.Selection[1];
                    mObj_ou_UserProperty = mObj_ou_MailItem.UserProperties.Add("JT", Microsoft.Office.Interop.Outlook.OlUserPropertyType.olText);
                    mObj_ou_UserProperty.Value = p_Procedure;
                    mObj_of_CommandBars = mObj_ou_Explorer.CommandBars;
    
                    //Call the clipboard event Copy
                    mObj_of_CommandBars.ExecuteMso("Copy");
                }
            }
        }
    }
