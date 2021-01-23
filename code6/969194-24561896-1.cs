    TextBox txt;
    for(int i = 1; i<=17; i++)
    {
        txt = (TextBox)Page.FindControl("tb" + i);
        if(string.IsNullOrEmpty(txt.Text))
            txt.Text = "n/a";
    }
