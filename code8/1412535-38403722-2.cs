    using System.Drawing;
    using System.Windows.Forms;
    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            BorderStyle = System.Windows.Forms.BorderStyle.None;
            AutoSize = false; //Allows you to change height to have bottom padding
            Controls.Add(new Label()
                        { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
        }
    }
