    public partial class TempleteForm : Form
    {
        public TextBox MyTextBox;
        public TempleteForm()
        {
            MyTextBox = new System.Windows.Forms.TextBox();
            this.Controls.Add(MyTextBox);
        }
    }
