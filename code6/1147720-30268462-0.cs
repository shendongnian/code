    private bool buttonDown; 
    private void btn1_MouseDown(object sender, MouseEventArgs e) 
    { 
        buttonDown = true; 
    
        int num = 0; 
        do 
        { 
            num++; 
            label1.Text = num.ToString(); 
    
            Application.DoEvents(); 
        } while (buttonDown); 
    } 
    
    private void btn1_MouseUp(object sender, MouseEventArgs e) 
    { 
        buttonDown = false; 
    } 
