    namespace Secretary_1._0
    {
     
        public partial class Client
        {
             public Form1 formCall;
              
             //Constructor
             public Client(Form1 form1)
             {
                  formCall = form1;
                  formCall.someButton.Click += OnSomeButtonClick;
             }
             
             public void OnSomeButtonClick(object sender, EventArgs e)
             {
                 //Code here to on form1 button click ...
             }
             
             public static void Clients_Click(object sender, EventArgs e)
             {     
                 formCall.clientPanel.Visible = true;
                 formCall.clientLabel.Visible = true;
                 formCall.addClientButton.Visible = true;
                 formCall.clientListPanel.Visible = true;
                 formCall.clientListPanel.BringToFront();
                 formCall.addClientLabel.Visible = false;
                 formCall.clientInfoPanel.Visible = false;
             }
             public static void addClientButton_Click(object sender, EventArgs e)
             {
                 formCall.clientPanel.Visible = true;
                 formCall.addClientLabel.Visible = true;
                 formCall.clientInfoPanel.Visible = true;
                 formCall.clientInfoPanel.BringToFront();
                 formCall.addClientButton.Visible = false;
                 formCall.clientListPanel.Visible = false;
                 formCall.clientAddPropertyPanel.Visible = false;
             }
         }
    }
