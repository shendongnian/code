    int[] testing = new int[lines.Length];
    
    textBox1.Clear(); //Just to clear it if button pressed again
    for (int i = 0; i < lines.Length; i++)
    {
        testing[i] = int.Parse(lines[i].Substring(16, 1));//just getting the needed value
        textBox1.Text += testing[i].ToString() + "\r\n" ;//adding each value to textBox1, separated by new line
    }
