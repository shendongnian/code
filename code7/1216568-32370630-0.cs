    public class NewClass
    {
        Form1 fm;
        public NewClass(Form1 frm)
        {
            fm=frm;
        }
        void ChangeTextBox()
        {
             fm.YourTextBox.Text="Foo";
        }
    }
