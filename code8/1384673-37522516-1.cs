    for (int i = 1; i < 6; i++)
    {
       string strTextbox = "textbox" + i.ToString();
       TextBox txt = this.FindControl(strTextbox) as TextBox;
       if (txt != null && !string.IsNullOrEmpty(txt.Text))
       {
          // ... 
       }
    }
