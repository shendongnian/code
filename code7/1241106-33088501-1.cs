    public partial class SecondForm : Form
    {
         MainForm form1 = null;
         public SecondForm(MainForm main_form)
         {
             form1 = main_form;
         }
         private void calltest()
         {
            form1.test();
         }
    ...
    }
