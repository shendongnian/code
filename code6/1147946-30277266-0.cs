    private void button4_Click(object sender, EventArgs e)
    {   
        if(!String.IsNullOrEmpty(Anexostxt.Text) && File.Exists(Anexostxt.Text))    
            msg.Attachments.Add(new Attachment(Anexostxt.Text));
        if(!String.IsNullOrEmpty(anexos2.Text) && File.Exists(anexos2.Text)) 
            msg.Attachments.Add(new Attachment(anexos2.Text));  
    }
