    protected void getQty(object sender, EventArgs e)
    {
        //After clicking "add"....
        string s;
        foreach(TextBox txt_item in gvChild.Children)
        {
            s = txt_item.Text;
        }
        //Do what you want to with this string
        //If you will be adding Textboxeses to this Grid use a List instead of one string
    }
