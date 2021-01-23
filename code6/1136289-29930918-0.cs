    public partial class CustomUserControl : UserControl
    {
       MainForm parentForm;
       public CustomUserControl(MainForm mainForm)
       {
          parentForm = mainForm;
       }
       ... 
       ...
       private void doSomthing()
       {
          parentForm.MainFormMember = 1;
       }
    }
