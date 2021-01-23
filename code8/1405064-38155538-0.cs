    //form1
    Form2 second = new Form2(this);
    }....
    public void ShowTextBox()
    {
        textbox1.Visible=true;
    }
    //form2
    Form parent;
    public Form2(Form _parent)
    {
        parent=_parent;
    }
    ///later
    parent.Show();
    parent.ShowTextBox();
