    var sb = new StringBuilder();
    for (int i = 0; i < text.Length; i++)
    {
        //...
        sb.Append(char.ToString(cipher));
    }
    textBox2.Text = sb.ToString();
