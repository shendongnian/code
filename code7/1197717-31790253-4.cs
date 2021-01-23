    public partial class Form1: Form
    {
        bool isHover = false;
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if(isHover) return;
            // with MouseHover this control visibility appears to be locked with MouseEnter it is not
            pictureBox2.Visible = false;
            pictureBox2.BackColor = Color.Black;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {            
            if(!isHover) return;
            isHover = false;
            pictureBox2.Visible = true;
        }
    ...
    
    }
