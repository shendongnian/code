    //mousemove inside my Textbox
        private void TextBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            //txt is the name oh my textbox
            txt.Text = e.GetPosition(this).ToString();
        }
        //mousemove in my windows
        private void wn_MouseMove(object sender, MouseEventArgs e)
        {
            //txt is the name oh my textbox
            txt.Text = e.GetPosition(this).ToString();
        }
