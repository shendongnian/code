    private void Form1_Shown(object sender, EventArgs e)
    {
         ChangeFontFamily(this);
    }
    
    private void ChangeFontFamily(Form _form)
    {
         for (int i = 0; i < _form.Controls.Count; i++)
         {
             _form.Controls[i].Font = new Font("Arial", _form.Controls[i].Font.Size, _form.Controls[i].Font.Style);
          }
    }
    
