    try
    {
       guess=int.Parse(textBox_Guess.Text);          
    }
    catch
    {
        label_Reveal.ForeColor = System.Drawing.Color.Red;
        label_Reveal.Text = "Your input is invalid!";    
        label_Reveal.Visible = true;      
    }
