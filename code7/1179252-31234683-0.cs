    public class MyForm:Form
    {
     private TextBox txbId;
     private TextBox txbSession;
     private TextBox txbClass;
     private TextBox txbSection;
     
     protected void InitializeComponent(){}//init all form's controls
     
     public MyForm()
     {
      InitializeComponent();
      //When some of the fields are changed then ID field is changing as well
      txbSection.TextChanged+=OnTxtChanged;
      txbClass.TextChanged+=OnTxtChanged;
      txbSession.TextChanged+=OnTxtChanged;
      //use separate method when txtId changed
      txbId.TextChanged+=OnIdTxtChanged;
     }
     
     private void OnTxtChanged(object sender, EventArgs args)
     {
       txbId.Text = txbSession.Text+txbClass.Text+txbSection.Text;
     }
     
     private void OnIdTxtChanged(object sender, EventArgs args)
     {
       //save your txbId.Text in DB here
     }
    }
