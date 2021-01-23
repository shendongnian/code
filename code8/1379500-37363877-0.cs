    foreach(Control c in Step2.Controls)
    {
       Textbox tb = c as TextBox;
       if (tb != null)
       {
           var tag = tb.Tag as int[];
           theMatrixArray[tag[0], tag[1]] = tb.Text; // Or parse it to int if you can't have it in text
       }
    }
