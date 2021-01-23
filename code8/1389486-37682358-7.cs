    protected void ChangeLabel_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        SecondFormType f = Application.OpenForms().OfType<SecondFormType>().FirstOrDefault();
        if(f != null)
        {
            if(btn.Name == "Button1")
               f.ChangeLabel("NewText 1");
            else if(btn.Name == "Button2")
               f.ChangeLabel("NewText 2");
            else if(btn.Name == "Button3")
               f.ChangeLabel("NewText 3");
        }
    }
