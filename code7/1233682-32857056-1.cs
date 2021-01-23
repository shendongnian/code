    List<TextBox> list = New List<TextBox>()
    //...
    list.Add(textbox1);
    list.Add(textbox2);'
    //...
    Then loop it
    foreach(TextBox txt in list)
    {
        if(String.IsNullOrWhiteSpace(txt.Text))
        {
            messagebox.Show("please fill in the boxes");
            break;
        }
    }
