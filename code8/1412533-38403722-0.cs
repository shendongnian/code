    using System.Drawing;
    using System.Windows.Forms;
    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Controls.Add(new Label()
            { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.Black });
        }
    }
