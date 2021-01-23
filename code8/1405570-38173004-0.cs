    private void TextBoxA_TextChanged(object sender, EventArgs e)
    {            
        int num = 0;
        if (int.TryParse(TextBoxA.Text, out num))
        {
            string text = (100 - num).ToString();
            TextBoxB.Text = text;
        }
    }
    
    private void TextBoxB_TextChanged(object sender, EventArgs e)
    {
        int num = 0;
        if (int.TryParse(TextBoxB.Text, out num))
        {
            string text = (100 - num).ToString();
            TextBoxA.Text = text;
        }
    }
