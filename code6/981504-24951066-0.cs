    public static void IsTxtNull(Textbox xTxt, string msg)
    {
        if(string.IsNullOrEmpty(xTxt.Text)
            MessageBox.Show(msg);
    }
