    if(form.TheRichTextBox.InvokeRequired)
    {
        form.TheRichTextBox.Invoke(new MethodInvoker(() => 
        {
            form.TheRichTextBox.Text += "I had to be invoked!";
        }));
    }
    else
    {
        form.TheRichTextBox.Text += "I didn't have to be invoked!";
    }
