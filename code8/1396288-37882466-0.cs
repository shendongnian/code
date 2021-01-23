    for (int i =0; i <3; i++)
    {
    TextBox _text = new TextBox();
    _text.Visible = true;
    _text.Text = i.ToString();
    _text.ID = i.ToString();
    form.Controls.Add(_text);
    }
