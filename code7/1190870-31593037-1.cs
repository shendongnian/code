    int[] testing = new int[lines.Length];
    for (int i = 0; i < lines.Length; i++)
    {
        testing[i] = int.Parse(lines[i].Substring(16, 1));
        textBox1.Text = testing.ToString();
    }
