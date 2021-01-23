    private void EasyTimer_Tick(object sender, EventArgs e) 
    {
        Bar.Left = Cursor.Position.X - (Bar.Width / 2); 
        Ball.Left += speed_Left; 
        Ball.Top += speed_Top; 
        
        if (Ball.Bottom >= Bar.Top && Ball.Bottom <= Bar.Bottom && Ball.Left    >= Bar.Left && Ball.Right <= Bar.Right)
        {
            speed_Top += 3;     
            speed_Left += 3;    
            speed_Top = -speed_Top;     
            Points += 1;        
            Easygamepoints.Text = Points.ToString();
        }
        if (Ball.Left <= Playground.Left)  
        ...
        ...
        if (Ball.Bottom >= Playground.Bottom) 
        {
            EasyTimer.Stop();    
            Cursor.Show();
    
            Lifes -= 1;
            if (Lifes == 0)
            {
                DialogResult ending;
                MessageBox.Show("all lifes have been used...", "lost ...", MessageBoxButtons.OK); 
                EndLife Final = new EndLife();  
                Final.Show();
                // You need to return whether or not the user wants to play another game from this form
                // See http://stackoverflow.com/questions/280579/how-do-i-pass-a-value-from-a-child-back-to-the-parent-form
                if (Final.NewGame == true)
                {
                    speed_Left = 5; 
                    speed_Top = 3;  
                    Ball.Top = 69;     
                    Ball.Left = 128;
                    Lifes = 3;
                    EasyTimer.Start();  
                }
                else
                    Close();
            }
            else
            {  
                DialogResult result = MessageBox.Show("You have lost one of your lives...", "You died, Life Lost...", MessageBoxButtons.OK);
                if (result == DialogResult.OK)        
                {
                    EasyTimer.Start();
                    Cursor.Hide();
                    EasyLife.Text = Lifes.ToString();
                    speed_Left = 5; 
                    speed_Top = 3;
                    Ball.Top = 69;     
                    Ball.Left = 128;                             
                }
                else
                    Close();
            }
        }
    }
