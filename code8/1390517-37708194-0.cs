    private void button1_Click(object sender, EventArgs e)
    {
       if(!String.IsNullOrEmpty(richTextBox1.Text))
       {
          Send(richTextBox1.Text);
       }
       else if(!String.IsNullOrEmpty(textBox1.Text))     
       {    
          Send(textBox1.Text);
       } 
       else
       {
           return;  
       }    
    }
