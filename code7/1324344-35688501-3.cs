    var sb = new StringBuilder(); //In namespace System.Text
    var x = Convert.ToInt32(textBox1.Text); //parse only once 
    for (int i = 1; i <= x; i++)
    {
        for (int j = 1; j <= x; j++)
        {
            sb.Append(Convert.ToString(i * j));
            sb.Append("\t ");
        }
        sb.Append("\n");
    }
    richTextBox1.Text += sb.ToString();
