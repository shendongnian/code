    void Button_Mouse_Move(object sender, EventArgs e)
            {
                if (e.Button.Equals(MouseButtons.None))
                {
                  _BPictureBox _Button = (PictureBox)sender;
                    _Button.ImageLocation = @"PATH\Button_Hover.jpg";
                }
            }
    
    void Button_Mouse_Click(object sender, EventArgs e)
    {
             if (e.Button.Equals(MouseButtons.Left))
                {
                  _Button.MouseEnter -= Button_Mouse_Enter;  
                   PictureBox _Button = (PictureBox)sender;
                  _Button.ImageLocation = @"PATH\Button_Click.jpg";
                }        
    }
