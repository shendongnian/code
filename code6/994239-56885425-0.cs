    isprocessing = true;
    form.FormClosing += new FormClosingEventHandler(form_cancel); 
    private void form_cancel(object sender, FormClosingEventArgs e)
    {
     if (isprocessing)
      {
        e.Cancel = true;  //disables the form close when processing is true
         }
         else
            {
             e.Cancel = false; //enables it later when processing is set to false at some point 
            }
        }
