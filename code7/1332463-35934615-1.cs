    private async void btncheckPassword_Click(object sender, EventArgs e)
    {
        if(txtPlainPasswordCheck.TextLength > 0 &&   txtHashedPasswordCheck.TextLength > 0)
        {
            bool isMatch = false;
            SetCursor(Cursors.WaitCursor);
            try
            {
               isMatch = await Task.Run(
                  () => 
                  {  
                     try
                     {
                        return BCrypt.Net.BCrypt.Verify(
                           (String)txtPlainPasswordCheck.Text,                    
                           (String)txtHashedPasswordCheck.Text)
                        );
                     }
                     catch
                     {
                        throw new BCrypt.Net.SaltParseException(); 
                     }
                  }
               ); 
               if (isMatch)
               {
                   SetCheckLabel("Passwords Match", Color.Black, Color.Green);
               }
               else
               {
                  SetCheckLabel("Passwords Don't Match", Color.Red, Color.Black);    
               }
            }
            catch (BCrypt.Net.SaltParseException e2)
            {
                SetCheckLabel(e2.Message.ToString(), Color.Red, Color.Black);
            }
            SetCursor(Cursors.Default);
        }
    }
